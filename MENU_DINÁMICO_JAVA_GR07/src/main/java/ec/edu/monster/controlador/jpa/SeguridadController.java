package ec.edu.monster.controlador.jpa;

import ec.edu.monster.entidades.jpa.Empleado;
import ec.edu.monster.entidades.jpa.Usuario;
import ec.edu.monster.servicios.jpa.EmpleadoServicio;
import ec.edu.monster.servicios.jpa.OpcPerServicio;
import ec.edu.monster.servicios.jpa.SeguridadServicio;
import jakarta.servlet.http.HttpSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.Map;
import java.util.Optional;
import java.util.Set;

@RestController
@RequestMapping("/api/seguridad")
@CrossOrigin(origins = "*") 
public class SeguridadController {

    @Autowired
    private SeguridadServicio seguridadServicio;

    @Autowired
    private EmpleadoServicio empleadoServicio;

    @Autowired
    private OpcPerServicio opcPerServicio;

    @PostMapping("/registro")
    public ResponseEntity<?> registrar(@RequestBody Map<String, String> payload) {
        try {
            String nombres = payload.get("nombres");
            String password = payload.get("password");
            Empleado emp = new Empleado();
            emp.setNombres(nombres);
            emp.setApellidos("Usuario Sistema");
            emp.setFechaNacimiento(new Date());  
            emp.setDireccion("Dirección Matriz Universidad"); 
            emp.setTelefono("0999999999");        
            emp.setCorreo("sistema@monster.edu.ec"); 
            emp.setCedula("1700000000");         
            emp.setDiscapacidad(false);          
            emp.setSalario(460.00f);             

            String estadoInicialEstatico = "A"; 

            Usuario usuarioCreado = seguridadServicio.registrarUsuario(emp, password, estadoInicialEstatico);
            
            return ResponseEntity.status(HttpStatus.CREATED)
                    .body("Tu CÓDIGO DE ACCESO generado es: " + usuarioCreado.getId());

        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST)
                    .body("Error al registrar: " + e.getMessage());
        }
    }

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody Map<String, String> credenciales, HttpSession session) {
        String codigo = credenciales.get("codigo");
        String password = credenciales.get("password");

        Optional<Usuario> usuarioOpt = seguridadServicio.buscarUsuario(codigo);
        if (usuarioOpt.isEmpty()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED)
                    .body("Código de empleado no registrado en el sistema.");
        }

        if (seguridadServicio.isBloqueado(codigo)) {
            long segs = seguridadServicio.segundosRestantesBloqueo(codigo);
            return ResponseEntity.status(HttpStatus.TOO_MANY_REQUESTS)
                    .body("Demasiados intentos fallidos. Intente de nuevo en " + segs + " segundos.");
        }

        Usuario usuario = usuarioOpt.get();
        if (usuario.getEstado() == null || !"A".equals(usuario.getEstado().getCodigo())) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED)
                    .body("Usuario inactivo. Contacte al administrador.");
        }

        boolean exito = seguridadServicio.autenticarUsuario(codigo, password);
        if (exito) {
            seguridadServicio.resetearIntentos(codigo);
            Empleado emp = empleadoServicio.obtenerPorCodigo(codigo.trim().toUpperCase());
            session.setAttribute("empleadoCodigo", emp.getCodigo());
            session.setAttribute("empleadoNombres", emp.getNombres() + " " + emp.getApellidos());
            Set<String> menus = opcPerServicio.obtenerMenusPermitidos(codigo.trim().toUpperCase());
            session.setAttribute("menusPermitidos", menus);
            Set<String> permisos = opcPerServicio.obtenerPermisosUsuario(codigo.trim().toUpperCase());
            session.setAttribute("permisos", permisos);
            return ResponseEntity.ok("¡Login Exitoso! Bienvenido al Aplicativo Monster.");
        } else {
            seguridadServicio.registrarIntentoFallido(codigo);
            if (seguridadServicio.isBloqueado(codigo)) {
                long segs = seguridadServicio.segundosRestantesBloqueo(codigo);
                return ResponseEntity.status(HttpStatus.TOO_MANY_REQUESTS)
                        .body("Demasiados intentos fallidos. Intente de nuevo en " + segs + " segundos.");
            }
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED)
                    .body("Contraseña incorrecta.");
        }
    }
}

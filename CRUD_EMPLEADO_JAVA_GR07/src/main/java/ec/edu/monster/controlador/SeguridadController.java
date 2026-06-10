package ec.edu.monster.controlador;

import ec.edu.monster.entidades.Empleado;
import ec.edu.monster.entidades.Usuario;
import ec.edu.monster.servicios.EmpleadoServicio;
import ec.edu.monster.servicios.SeguridadServicio;
import jakarta.servlet.http.HttpSession;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.Map;

@RestController
@RequestMapping("/api/seguridad")
@CrossOrigin(origins = "*") 
public class SeguridadController {

    @Autowired
    private SeguridadServicio seguridadServicio;

    @Autowired
    private EmpleadoServicio empleadoServicio;

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

        boolean exito = seguridadServicio.autenticarUsuario(codigo, password);

        if (exito) {
            Empleado emp = empleadoServicio.obtenerPorCodigo(codigo.trim().toUpperCase());
            session.setAttribute("empleadoCodigo", emp.getCodigo());
            session.setAttribute("empleadoNombres", emp.getNombres() + " " + emp.getApellidos());
            return ResponseEntity.ok("¡Login Exitoso! Bienvenido al Aplicativo Monster.");
        } else {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED)
                    .body("Código de empleado o contraseña incorrectos.");
        }
    }
}
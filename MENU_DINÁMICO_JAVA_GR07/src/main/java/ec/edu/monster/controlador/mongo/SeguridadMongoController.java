package ec.edu.monster.controlador.mongo;

import ec.edu.monster.entidades.mongo.UsuarioEmpleadoDocumento;
import ec.edu.monster.servicios.jpa.OpcPerServicio;
import ec.edu.monster.servicios.mongo.SeguridadMongoServicio;
import jakarta.servlet.http.HttpSession;
import java.util.Map;
import java.util.Optional;
import java.util.Set;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

//@RestController
//@RequestMapping("/api/seguridad/mongo")
//@CrossOrigin(origins = "*")
public class SeguridadMongoController {

    @Autowired
    private SeguridadMongoServicio seguridadMongoServicio;

    @Autowired
    private OpcPerServicio opcPerServicio;

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody Map<String, String> credenciales, HttpSession session) {
        String codigo = credenciales.get("codigo");
        String password = credenciales.get("password");

        Optional<UsuarioEmpleadoDocumento> usuarioOpt = seguridadMongoServicio.buscarUsuario(codigo);
        if (usuarioOpt.isEmpty()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED)
                    .body("Código de empleado no registrado en el sistema.");
        }

        if (seguridadMongoServicio.isBloqueado(codigo)) {
            long segs = seguridadMongoServicio.segundosRestantesBloqueo(codigo);
            return ResponseEntity.status(HttpStatus.TOO_MANY_REQUESTS)
                    .body("Demasiados intentos fallidos. Intente de nuevo en " + segs + " segundos.");
        }

        UsuarioEmpleadoDocumento usuario = usuarioOpt.get();
        boolean exito = seguridadMongoServicio.autenticarUsuario(codigo, password);
        if (exito) {
            seguridadMongoServicio.resetearIntentos(codigo);
            UsuarioEmpleadoDocumento.EmpleadoNoSQL emp = usuario.getDatosEmpleado();
            session.setAttribute("empleadoCodigo", emp.getCodigo());
            session.setAttribute("empleadoNombres", emp.getNombres() + " " + emp.getApellidos());
            Set<String> menus = opcPerServicio.obtenerMenusPermitidos(emp.getCodigo().trim().toUpperCase());
            session.setAttribute("menusPermitidos", menus);
            Set<String> permisos = opcPerServicio.obtenerPermisosUsuario(emp.getCodigo().trim().toUpperCase());
            session.setAttribute("permisos", permisos);
            return ResponseEntity.ok("¡Login Exitoso! Bienvenido al Aplicativo Monster.");
        } else {
            seguridadMongoServicio.registrarIntentoFallido(codigo);
            if (seguridadMongoServicio.isBloqueado(codigo)) {
                long segs = seguridadMongoServicio.segundosRestantesBloqueo(codigo);
                return ResponseEntity.status(HttpStatus.TOO_MANY_REQUESTS)
                        .body("Demasiados intentos fallidos. Intente de nuevo en " + segs + " segundos.");
            }
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED)
                    .body("Contraseña incorrecta.");
        }
    }
}

package ec.edu.monster.controlador;

import ec.edu.monster.entidades.Empleado;
import ec.edu.monster.entidades.Usuario;
import ec.edu.monster.servicios.EmpleadoServicio;
import ec.edu.monster.servicios.SeguridadServicio;
import java.util.Map;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
@RequestMapping("/api/empleados")
@CrossOrigin(origins = "*")
public class EmpleadoController {

    @Autowired
    private EmpleadoServicio empleadoServicio;

    @Autowired
    private SeguridadServicio seguridadServicio;

    @GetMapping
    public ResponseEntity<List<Empleado>> listar() {
        return ResponseEntity.ok(empleadoServicio.listarTodos());
    }

    @PostMapping
    public ResponseEntity<?> crear(@RequestBody Empleado nuevo, @RequestParam(required = false) String cargoCodigo) {
        try {
            Empleado guardado = empleadoServicio.guardar(nuevo, cargoCodigo);
            return ResponseEntity.status(HttpStatus.CREATED).body(guardado);
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al registrar: " + e.getMessage());
        }
    }

    @PutMapping("/{codigo}")
    public ResponseEntity<?> actualizar(@PathVariable String codigo, @RequestBody Empleado datos, @RequestParam(required = false) String cargoCodigo) {
        String codigoLimpio = codigo.trim().toUpperCase();
        try {
            Empleado actualizado = empleadoServicio.editar(codigoLimpio, datos, cargoCodigo);
            return ResponseEntity.ok(actualizado);
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al actualizar: " + e.getMessage());
        }
    }

    @DeleteMapping("/{codigo}")
    public ResponseEntity<?> eliminar(@PathVariable String codigo) {
        String codigoLimpio = codigo.trim().toUpperCase();
        try {
            empleadoServicio.eliminar(codigoLimpio);
            return ResponseEntity.ok("Empleado eliminado correctamente.");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al eliminar: " + e.getMessage());
        }
    }

    @GetMapping("/{codigo}/foto")
    public ResponseEntity<byte[]> obtenerFoto(@PathVariable String codigo) {
        try {
            Empleado emp = empleadoServicio.obtenerPorCodigo(codigo.trim().toUpperCase());
            if (emp.getFoto() != null) {
                HttpHeaders headers = new HttpHeaders();
                headers.setContentType(MediaType.IMAGE_JPEG);
                return new ResponseEntity<>(emp.getFoto(), headers, HttpStatus.OK);
            }
        } catch (Exception e) {
        }
        return ResponseEntity.notFound().build();
    }

    @GetMapping("/{codigo}/usuario")
    public ResponseEntity<?> obtenerUsuario(@PathVariable String codigo) {
        String codigoLimpio = codigo.trim().toUpperCase();
        Optional<Usuario> usuarioOpt = seguridadServicio.buscarUsuario(codigoLimpio);
        if (usuarioOpt.isEmpty()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("El empleado no tiene un usuario registrado.");
        }

        Usuario usuario = usuarioOpt.get();
        Map<String, Object> response = Map.of(
            "id", usuario.getId(),
            "empleadoCodigo", usuario.getId(),
            "estado", Map.of("codigo", usuario.getEstado().getCodigo(), "descripcion", usuario.getEstado().getDescripcion()),
            "fechaCreacion", usuario.getFechaCreacion() != null ? usuario.getFechaCreacion().toString() : null,
            "pieFirma", usuario.getPieFirma() != null ? usuario.getPieFirma() : "",
            "tieneUsuario", true
        );
        return ResponseEntity.ok(response);
    }

    @PostMapping("/{codigo}/usuario")
    public ResponseEntity<?> crearUsuario(@PathVariable String codigo, @RequestBody Map<String, String> body) {
        String codigoLimpio = codigo.trim().toUpperCase();
        String password = body.get("password");

        if (password == null || password.trim().isEmpty()) {
            return ResponseEntity.badRequest().body("Debe ingresar una contraseña.");
        }
        if (password.length() < 4) {
            return ResponseEntity.badRequest().body("La contraseña debe tener al menos 4 caracteres.");
        }

        try {
            Usuario usuario = seguridadServicio.crearUsuarioParaEmpleado(codigoLimpio, password);
            return ResponseEntity.status(HttpStatus.CREATED).body(Map.of(
                "mensaje", "Usuario creado exitosamente.",
                "codigo", usuario.getId()
            ));
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al crear usuario: " + e.getMessage());
        }
    }

    @PutMapping("/{codigo}/usuario")
    public ResponseEntity<?> actualizarUsuario(@PathVariable String codigo, @RequestBody Map<String, String> body) {
        String codigoLimpio = codigo.trim().toUpperCase();

        try {
            String password = body.get("password");
            if (password != null && !password.trim().isEmpty()) {
                if (password.length() < 4) {
                    return ResponseEntity.badRequest().body("La contraseña debe tener al menos 4 caracteres.");
                }
                seguridadServicio.actualizarPassword(codigoLimpio, password);
            }

            String estado = body.get("estado");
            if (estado != null && !estado.trim().isEmpty()) {
                seguridadServicio.cambiarEstado(codigoLimpio, estado.trim().toUpperCase());
            }

            return ResponseEntity.ok("Usuario actualizado exitosamente.");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al actualizar usuario: " + e.getMessage());
        }
    }
}

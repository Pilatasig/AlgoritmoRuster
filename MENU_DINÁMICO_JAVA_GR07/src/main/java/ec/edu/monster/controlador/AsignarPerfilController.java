package ec.edu.monster.controlador;

import ec.edu.monster.entidades.Usuario;
import ec.edu.monster.entidades.Usuper;
import ec.edu.monster.servicios.AsignarPerfilServicio;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/asignar-perfiles")
@CrossOrigin(origins = "*")
public class AsignarPerfilController {

    @Autowired
    private AsignarPerfilServicio asignarPerfilServicio;

    @GetMapping("/{perfilCodigo}/asignados")
    public ResponseEntity<List<Usuper>> listarAsignados(@PathVariable String perfilCodigo) {
        return ResponseEntity.ok(asignarPerfilServicio.listarAsignados(perfilCodigo));
    }

    @GetMapping("/{perfilCodigo}/disponibles")
    public ResponseEntity<List<Usuario>> listarDisponibles(@PathVariable String perfilCodigo) {
        return ResponseEntity.ok(asignarPerfilServicio.listarDisponibles(perfilCodigo));
    }

    @PostMapping("/{perfilCodigo}/asignar/{usuarioId}")
    public ResponseEntity<?> asignarUsuario(@PathVariable String perfilCodigo, @PathVariable String usuarioId) {
        try {
            asignarPerfilServicio.asignarUsuario(perfilCodigo, usuarioId);
            return ResponseEntity.ok("Usuario asignado al perfil correctamente.");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al asignar: " + e.getMessage());
        }
    }

    @DeleteMapping("/{perfilCodigo}/remover/{usuarioId}")
    public ResponseEntity<?> removerUsuario(@PathVariable String perfilCodigo, @PathVariable String usuarioId) {
        try {
            asignarPerfilServicio.removerUsuario(perfilCodigo, usuarioId);
            return ResponseEntity.ok("Usuario removido del perfil correctamente.");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al remover: " + e.getMessage());
        }
    }
}

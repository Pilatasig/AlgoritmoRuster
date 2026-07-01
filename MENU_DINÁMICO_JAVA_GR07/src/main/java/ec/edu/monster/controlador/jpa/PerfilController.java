package ec.edu.monster.controlador.jpa;

import ec.edu.monster.entidades.jpa.Perfil;
import ec.edu.monster.servicios.jpa.PerfilServicio;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/perfiles")
@CrossOrigin(origins = "*")
public class PerfilController {

    @Autowired
    private PerfilServicio perfilServicio;

    @GetMapping
    public ResponseEntity<List<Perfil>> listar() {
        return ResponseEntity.ok(perfilServicio.listarPerfiles());
    }

    @PostMapping
    public ResponseEntity<?> crear(@RequestBody Perfil nuevoPerfil) {
        try {
            if (nuevoPerfil.getNombre() == null || nuevoPerfil.getNombre().trim().length() != 3) {
                return ResponseEntity.badRequest().body("Error: El nombre del perfil debe tener exactamente 3 caracteres (Ej: ADM).");
            }
            if (nuevoPerfil.getDescripcion() == null || nuevoPerfil.getDescripcion().trim().isEmpty()) {
                return ResponseEntity.badRequest().body("Error: Debe ingresar una descripción para el perfil.");
            }
            Perfil perfilGuardado = perfilServicio.guardar(nuevoPerfil);
            return ResponseEntity.status(HttpStatus.CREATED).body(perfilGuardado);
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al crear el perfil: " + e.getMessage());
        }
    }

    @PutMapping("/{codigo}")
    public ResponseEntity<?> actualizar(@PathVariable String codigo, @RequestBody Perfil perfilDatos) {
        String codigoLimpio = codigo.trim().toUpperCase();

        return perfilServicio.obtenerPorCodigo(codigoLimpio)
                .map(perfilExistente -> {
                    try {
                        perfilExistente.setNombre(perfilDatos.getNombre());
                        perfilExistente.setDescripcion(perfilDatos.getDescripcion());
                        perfilExistente.setObservaciones(perfilDatos.getObservaciones());

                        perfilServicio.guardar(perfilExistente);
                        return ResponseEntity.ok("Perfil actualizado con éxito.");
                    } catch (Exception e) {
                        return ResponseEntity.badRequest().body("Error al actualizar internamente: " + e.getMessage());
                    }
                })
                .orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).body("Error: Perfil no localizado con el código: " + codigoLimpio));
    }

    @DeleteMapping("/{codigo}")
    public ResponseEntity<?> eliminar(@PathVariable String codigo) {
        String codigoLimpio = codigo.trim().toUpperCase();

        if (perfilServicio.obtenerPorCodigo(codigoLimpio).isEmpty()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Error: El perfil que intenta eliminar no existe.");
        }

        try {
            perfilServicio.eliminar(codigoLimpio);
            return ResponseEntity.ok("Perfil eliminado de la base de datos de manera correcta.");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error de integridad: No se puede eliminar porque tiene registros dependientes. " + e.getMessage());
        }
    }
}

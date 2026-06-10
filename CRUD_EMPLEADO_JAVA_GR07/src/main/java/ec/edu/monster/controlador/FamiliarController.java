package ec.edu.monster.controlador;

import ec.edu.monster.entidades.Familiar;
import ec.edu.monster.servicios.FamiliarServicio;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/familiares")
@CrossOrigin(origins = "*")
public class FamiliarController {

    @Autowired
    private FamiliarServicio familiarServicio;

    @GetMapping
    public ResponseEntity<List<Familiar>> listar(@RequestParam("empleadoCodigo") String empleadoCodigo) {
        return ResponseEntity.ok(familiarServicio.listarPorEmpleado(empleadoCodigo));
    }

    @PostMapping
    public ResponseEntity<?> crear(@RequestBody Familiar nuevo) {
        try {
            Familiar guardado = familiarServicio.guardar(nuevo);
            return ResponseEntity.status(HttpStatus.CREATED).body(guardado);
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al registrar familiar: " + e.getMessage());
        }
    }

    @PutMapping("/{empleadoCodigo}/{codigo}")
    public ResponseEntity<?> actualizar(@PathVariable String empleadoCodigo, @PathVariable String codigo, @RequestBody Familiar datos) {
        try {
            Familiar actualizado = familiarServicio.editar(empleadoCodigo.trim().toUpperCase(), codigo.trim().toUpperCase(), datos);
            return ResponseEntity.ok(actualizado);
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al actualizar familiar: " + e.getMessage());
        }
    }

    @DeleteMapping("/{empleadoCodigo}/{codigo}")
    public ResponseEntity<?> eliminar(@PathVariable String empleadoCodigo, @PathVariable String codigo) {
        try {
            familiarServicio.eliminar(empleadoCodigo.trim().toUpperCase(), codigo.trim().toUpperCase());
            return ResponseEntity.ok("Familiar eliminado correctamente.");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al eliminar familiar: " + e.getMessage());
        }
    }
}

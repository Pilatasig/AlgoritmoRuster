package ec.edu.monster.controlador;

import ec.edu.monster.entidades.Empleado;
import ec.edu.monster.servicios.EmpleadoServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
@RequestMapping("/api/empleados")
@CrossOrigin(origins = "*")
public class EmpleadoController {

    @Autowired
    private EmpleadoServicio empleadoServicio;

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
    public ResponseEntity<?> actualizar(@PathVariable String codigo, @RequestBody Empleado datos) {
        String codigoLimpio = codigo.trim().toUpperCase();
        try {
            Empleado actualizado = empleadoServicio.editar(codigoLimpio, datos);
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
}
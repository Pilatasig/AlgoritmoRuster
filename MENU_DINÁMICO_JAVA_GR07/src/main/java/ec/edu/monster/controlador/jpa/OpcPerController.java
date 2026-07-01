package ec.edu.monster.controlador.jpa;

import ec.edu.monster.servicios.jpa.OpcPerServicio;
import java.util.List;
import java.util.Map;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/opciones-perfil")
@CrossOrigin(origins = "*")
public class OpcPerController {

    @Autowired
    private OpcPerServicio opcPerServicio;

    @GetMapping("/{perfilCodigo}")
    public ResponseEntity<List<Map<String, Object>>> obtenerArbol(@PathVariable String perfilCodigo) {
        return ResponseEntity.ok(opcPerServicio.obtenerArbolOpciones(perfilCodigo.toUpperCase().trim()));
    }

    @PostMapping("/{perfilCodigo}")
    public ResponseEntity<?> guardarAsignaciones(
            @PathVariable String perfilCodigo,
            @RequestBody Map<String, Object> cuerpo) {
        try {
            opcPerServicio.guardarAsignaciones(perfilCodigo.toUpperCase().trim(), cuerpo);
            return ResponseEntity.ok("Asignaciones guardadas correctamente.");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al guardar: " + e.getMessage());
        }
    }
}
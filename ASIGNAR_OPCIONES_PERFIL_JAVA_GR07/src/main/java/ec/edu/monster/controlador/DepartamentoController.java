package ec.edu.monster.controlador;

import ec.edu.monster.entidades.Departamento;
import ec.edu.monster.servicios.DepartamentoServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/departamentos")
@CrossOrigin(origins = "*", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE})
public class DepartamentoController {

    @Autowired
    private DepartamentoServicio deparServicio;

    @GetMapping
    public List<Departamento> listar() {
        return deparServicio.listarTodos();
    }

    @PostMapping
    public ResponseEntity<?> crear(@RequestBody Departamento depar) {
        try {
            Departamento creado = deparServicio.guardar(depar);
            return ResponseEntity.ok(creado);
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al crear: " + e.getMessage());
        }
    }

    @PutMapping("/{codigo}")
    public ResponseEntity<?> editar(@PathVariable("codigo") String codigo, @RequestBody Map<String, String> payload) {
        try {
            String codigoLimpio = codigo.trim().toUpperCase();

            // CORRECCIÓN DE LLAVES: Extraemos usando los nombres exactos que enviará el JSON
            String nuevoNombre = payload.get("nombre"); 
            String nuevaDesc = payload.get("descripcion");

            // Imprime en consola para depuración (opcional, te ayudará a ver qué llega)
            System.out.println("Modificando código: " + codigoLimpio);
            System.out.println("Nuevo Nombre (Nemónico): " + nuevoNombre);
            System.out.println("Nueva Descripción: " + nuevaDesc);

            // Validación preventiva corregida
            if (nuevoNombre == null || nuevaDesc == null) {
                return ResponseEntity.badRequest().body("Error: Los datos del formulario llegaron incompletos al servidor.");
            }

            // Invocamos al servicio usando el método que graba en la base de datos
            Departamento editado = deparServicio.editarDepartamento(codigoLimpio, nuevoNombre, nuevaDesc);
            return ResponseEntity.ok(editado);
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al editar: " + e.getMessage());
        }
    }

    @DeleteMapping("/{codigo}")
    public ResponseEntity<?> eliminar(@PathVariable("codigo") String codigo) {
        try {
            String codigoLimpio = codigo.trim().toUpperCase();  
            deparServicio.eliminar(codigoLimpio);
            return ResponseEntity.ok("Eliminado correctamente");
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al eliminar: " + e.getMessage());
        }
    }
}
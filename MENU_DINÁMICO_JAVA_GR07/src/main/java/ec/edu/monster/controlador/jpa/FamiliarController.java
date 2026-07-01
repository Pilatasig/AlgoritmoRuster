package ec.edu.monster.controlador.jpa;

import ec.edu.monster.entidades.jpa.Familiar;
import ec.edu.monster.servicios.jpa.FamiliarServicio;
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
        System.out.println("=== [FAMILIAR CONTROLLER] crear() ===");
        System.out.println("id.codigoEmpleado: " + (nuevo.getId() != null ? nuevo.getId().getCodigoEmpleado() : "NULL"));
        System.out.println("cedula: " + nuevo.getCedula());
        System.out.println("nombres: " + nuevo.getNombres());
        System.out.println("apellidos: " + nuevo.getApellidos());
        System.out.println("fechaNacimiento: " + nuevo.getFechaNacimiento());
        System.out.println("sexo.codigo: " + (nuevo.getSexo() != null ? nuevo.getSexo().getCodigo() : "NULL"));
        try {
            Familiar guardado = familiarServicio.guardar(nuevo);
            System.out.println("=== [FAMILIAR CONTROLLER] Guardado OK, codigo=" + guardado.getId().getCodigo() + " ===");
            return ResponseEntity.status(HttpStatus.CREATED).body(guardado);
        } catch (Exception e) {
            System.err.println("=== [FAMILIAR CONTROLLER] Error: " + e.getMessage() + " ===");
            e.printStackTrace();
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

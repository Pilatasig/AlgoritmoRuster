package ec.edu.monster.controlador.jpa;

import ec.edu.monster.entidades.jpa.Cargo;
import ec.edu.monster.servicios.jpa.CargoServicio;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

/**
 * Controlador REST robusto para la gestión de Cargos
 * @author Usuario
 */
@RestController
@RequestMapping("/api/cargos")
@CrossOrigin(origins = "*")
public class CargoController {
    
    @Autowired
    private CargoServicio cargoServicio;
    
    // GET: /api/cargos -> Lista todos los cargos con sus trims aplicados
    @GetMapping
    public ResponseEntity<List<Cargo>> listar(){
        return ResponseEntity.ok(cargoServicio.listarCargos());
    }
    
    // POST: /api/cargos -> El JSON viaja SIN 'codigo'. El servicio generará el "CARXXX"
    @PostMapping
    public ResponseEntity<?> crear(@RequestBody Cargo nuevoCargo){
        try {
            // VALIDACIÓN 1: El nemónico de 3 letras (nombre) sí es obligatorio desde el formulario
            if (nuevoCargo.getNombre() == null || nuevoCargo.getNombre().trim().length() != 3) {
                return ResponseEntity.badRequest().body("Error: El código nemónico del cargo debe tener exactamente 3 caracteres (Ej: GER).");
            }
            
            // VALIDACIÓN 2: Es obligatorio amarrar el cargo a una área/departamento existente
            if (nuevoCargo.getDepartamento() == null || nuevoCargo.getDepartamento().getCodigo() == null) {
                return ResponseEntity.badRequest().body("Error: Debe asociar un departamento válido a este cargo.");
            }
            
            // Delegamos de forma limpia el cálculo del ID ("CARXXX") y la persistencia a la capa de servicio
            Cargo cargoGuardado = cargoServicio.guardar(nuevoCargo);
            return ResponseEntity.status(HttpStatus.CREATED).body(cargoGuardado);
            
        } catch (Exception e) {
            return ResponseEntity.badRequest().body("Error al crear el cargo: " + e.getMessage());
        }
    }
    
    // PUT: /api/cargos/CAR001 -> Actualiza nemónico, descripción y departamento asociado
    @PutMapping("/{codigo}")
    public ResponseEntity<?> actualizar(@PathVariable String codigo, @RequestBody Cargo cargoDatos){
        String codigoLimpio = codigo.trim().toUpperCase();
        
        return cargoServicio.obtenerPorCodigo(codigoLimpio)
                .map(cargoExistente -> {
                    try {
                        // Sincronizamos todos los campos modificables de la entidad original
                        cargoExistente.setNombre(cargoDatos.getNombre());
                        cargoExistente.setDescripcion(cargoDatos.getDescripcion());
                        cargoExistente.setDepartamento(cargoDatos.getDepartamento());
                        
                        cargoServicio.guardar(cargoExistente);
                        return ResponseEntity.ok("Cargo actualizado con éxito.");
                    } catch (Exception e) {
                        return ResponseEntity.badRequest().body("Error al actualizar internamente: " + e.getMessage());
                    }
                })
                .orElseGet(() -> ResponseEntity.status(HttpStatus.NOT_FOUND).body("Error: Cargo no localizado con el código: " + codigoLimpio));
    }
    
    // DELETE: /api/cargos/CAR001
    @DeleteMapping("/{codigo}")
    public ResponseEntity<?> eliminar(@PathVariable String codigo){
        String codigoLimpio = codigo.trim().toUpperCase();
        
        if (cargoServicio.obtenerPorCodigo(codigoLimpio).isEmpty()) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Error: El cargo que intenta eliminar no existe.");
        }
        
        try {
            cargoServicio.eliminar(codigoLimpio);
            return ResponseEntity.ok("Cargo eliminado de la base de datos de manera correcta.");
        } catch (Exception e) {
            // Captura errores por si viola integridad referencial (ej: si hay empleados asignados a este cargo)
            return ResponseEntity.badRequest().body("Error de integridad: No se puede eliminar porque tiene registros dependientes. " + e.getMessage());
        }
    }
}
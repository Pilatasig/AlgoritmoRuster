package ec.edu.monster.servicios;

import ec.edu.monster.entidades.Cargo;
import ec.edu.monster.entidades.Departamento;
import ec.edu.monster.repositorio.CargoRepositorio;
import ec.edu.monster.repositorio.DepartamentoRepositorio;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class CargoServicio {
    
    @Autowired
    private CargoRepositorio cargoRepo;

    @Autowired
    private DepartamentoRepositorio departamentoRepo;
    
    @Transactional(readOnly = true)
    public List<Cargo> listarCargos(){
        List<Cargo> lista = cargoRepo.findAllWithAsignaciones();
        lista.forEach(c -> {
            if (c.getCodigo() != null) c.setCodigo(c.getCodigo().trim());
            if (c.getNombre() != null) c.setNombre(c.getNombre().trim());
            if (c.getDescripcion() != null) c.setDescripcion(c.getDescripcion().trim());
            
            if (c.getDepartamento() != null && c.getDepartamento().getCodigo() != null) {
                c.getDepartamento().setCodigo(c.getDepartamento().getCodigo().trim());
            }
        });
        return lista;
    }
    
    @Transactional(readOnly = true)
    public Optional<Cargo> obtenerPorCodigo(String codigo){
        if (codigo == null) return Optional.empty();
        return cargoRepo.findByIdCodigo(codigo.trim().toUpperCase());
    }
    
    @Transactional
    public Cargo guardar(Cargo cargo){
        if (cargo.getCodigo() == null || cargo.getCodigo().trim().isEmpty()) {
            String nuevoCodigo = generarSiguienteCodigo();
            cargo.setCodigo(nuevoCodigo);
        } else {
            cargo.setCodigo(cargo.getCodigo().toUpperCase().trim());
        }
        
        if (cargo.getNombre() != null) {
            cargo.setNombre(cargo.getNombre().toUpperCase().trim());
        }
        
        if (cargo.getDescripcion() != null) {
            cargo.setDescripcion(cargo.getDescripcion().trim());
        }
        
        if (cargo.getDepartamento() != null && cargo.getDepartamento().getCodigo() != null) {
            Departamento dep = departamentoRepo.findById(cargo.getDepartamento().getCodigo().trim().toUpperCase())
                .orElseThrow(() -> new RuntimeException("Departamento no encontrado"));
            cargo.setDepartamento(dep);
        }
        
        return cargoRepo.saveAndFlush(cargo);
    }
    
    @Transactional
    public void eliminar(String codigo){
        String codigoLimpio = codigo.trim().toUpperCase();
        if (!cargoRepo.existsById(codigoLimpio)) {
            throw new RuntimeException("El cargo con código " + codigoLimpio + " no existe.");
        }
        cargoRepo.deleteById(codigoLimpio);
    }
    
    private String generarSiguienteCodigo() {
        List<Cargo> todos = cargoRepo.findAll();
        
        Optional<String> maxCodigoOpt = todos.stream()
            .map(Cargo::getCodigo)
            .filter(c -> c != null && c.trim().toUpperCase().startsWith("CAR"))
            .max(String::compareTo);

        if (maxCodigoOpt.isEmpty()) {
            return "CAR001";
        }

        String ultimoCodigoStr = maxCodigoOpt.get().trim();
        String parteNumericaStr = ultimoCodigoStr.substring(3);
        
        try {
            int ultimoNumero = Integer.parseInt(parteNumericaStr);
            int siguienteNumero = ultimoNumero + 1;
            
            return String.format("CAR%03d", siguienteNumero);
        } catch (NumberFormatException e) {
            return "CAR" + String.format("%03d", todos.size() + 1);
        }
    }
}

package ec.edu.monster.servicios;

import ec.edu.monster.entidades.Departamento;
import ec.edu.monster.repositorio.DepartamentoRepositorio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import java.util.List;
import java.util.Optional;

@Service
public class DepartamentoServicio {

    @Autowired
    private DepartamentoRepositorio deparRep;

    public List<Departamento> listarTodos() {
        List<Departamento> lista = deparRep.findAll();
        
        lista.forEach(d -> {
            if(d.getCodigo()!=null) d.setCodigo(d.getCodigo().trim());
            if(d.getNombre()!=null) d.setNombre(d.getNombre().trim());
            if(d.getDescripcion()!= null) d.setDescripcion(d.getDescripcion().trim());
            });
        return lista;
    }

    public Optional<Departamento> buscarPorId(String codigo) {
        return deparRep.findById(codigo.trim().toUpperCase());
    }

    @Transactional
    public Departamento guardar(Departamento depar) {
        if (depar.getCodigo() == null || depar.getCodigo().trim().isEmpty()) {
            String nuevoCodigo = generarSiguienteCodigo();
            depar.setCodigo(nuevoCodigo);
        } else {
            depar.setCodigo(depar.getCodigo().trim().toUpperCase());
        }

        if (depar.getNombre() != null) {
            depar.setNombre(depar.getNombre().trim().toUpperCase());
        }

        return deparRep.save(depar);
    }

    @Transactional
    public Departamento editarDepartamento(String codigo, String nuevoNombre,String nuevaDescripcion) {
        Departamento depar = deparRep.findById(codigo)
            .orElseThrow(() -> new RuntimeException("Departamento no encontrado: " + codigo));
        
        if (nuevoNombre != null) depar.setNombre(nuevoNombre.trim().toUpperCase());
        if (nuevaDescripcion!= null) depar.setDescripcion(nuevaDescripcion.trim());
        return deparRep.save(depar);
    }

    @Transactional
    public void eliminar(String codigo) {
        String codigoLimpio= codigo.trim().toUpperCase();
        if (!deparRep.existsById(codigoLimpio)) {
            throw new RuntimeException("El departamento no existe.");
        }
        deparRep.deleteById(codigoLimpio);
    }
    
    private String generarSiguienteCodigo(){
        List<Departamento> todos= deparRep.findAll();
        
        Optional<String> maxCodiOptional= todos.stream()
                .map(Departamento::getCodigo)
                .filter(c-> c!=null && c.trim().toUpperCase().startsWith("DEP"))
                .max(String::compareTo);
        
        if(maxCodiOptional.isEmpty())
            return "DEP001";
        
        String ultimoCodigoStr = maxCodiOptional.get().trim();
        String parteNumericaStr= ultimoCodigoStr.substring(3);
        
        try{
            int ultimoNumero = Integer.parseInt(parteNumericaStr);
            int siguienteNumero= ultimoNumero+1;
            
            return String.format("DEP%03d", siguienteNumero);
        }
        catch(NumberFormatException e){
            return "DEP"+ String.format("%03d", todos.size()+1);
        }
        
    }
    
}
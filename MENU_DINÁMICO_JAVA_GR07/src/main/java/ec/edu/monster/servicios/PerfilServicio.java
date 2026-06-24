package ec.edu.monster.servicios;

import ec.edu.monster.entidades.Perfil;
import ec.edu.monster.repositorio.PerfilRepositorio;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class PerfilServicio {

    @Autowired
    private PerfilRepositorio perfilRepo;

    @Transactional(readOnly = true)
    public List<Perfil> listarPerfiles() {
        List<Perfil> lista = perfilRepo.findAll();
        lista.forEach(p -> {
            if (p.getCodigo() != null) p.setCodigo(p.getCodigo().trim());
            if (p.getNombre() != null) p.setNombre(p.getNombre().trim());
            if (p.getDescripcion() != null) p.setDescripcion(p.getDescripcion().trim());
        });
        return lista;
    }

    @Transactional(readOnly = true)
    public Optional<Perfil> obtenerPorCodigo(String codigo) {
        if (codigo == null) return Optional.empty();
        return perfilRepo.findById(codigo.trim().toUpperCase());
    }

    @Transactional
    public Perfil guardar(Perfil perfil) {
        if (perfil.getCodigo() == null || perfil.getCodigo().trim().isEmpty()) {
            String nuevoCodigo = generarSiguienteCodigo();
            perfil.setCodigo(nuevoCodigo);
        } else {
            perfil.setCodigo(perfil.getCodigo().toUpperCase().trim());
        }

        if (perfil.getNombre() != null) {
            perfil.setNombre(perfil.getNombre().toUpperCase().trim());
        }

        if (perfil.getDescripcion() != null) {
            perfil.setDescripcion(perfil.getDescripcion().trim());
        }

        return perfilRepo.saveAndFlush(perfil);
    }

    @Transactional
    public void eliminar(String codigo) {
        String codigoLimpio = codigo.trim().toUpperCase();
        if (!perfilRepo.existsById(codigoLimpio)) {
            throw new RuntimeException("El perfil con código " + codigoLimpio + " no existe.");
        }
        perfilRepo.deleteById(codigoLimpio);
    }

    private String generarSiguienteCodigo() {
        List<Perfil> todos = perfilRepo.findAll();

        Optional<String> maxCodigoOpt = todos.stream()
            .map(Perfil::getCodigo)
            .filter(c -> c != null && c.trim().toUpperCase().startsWith("PER"))
            .max(String::compareTo);

        if (maxCodigoOpt.isEmpty()) {
            return "PER001";
        }

        String ultimoCodigoStr = maxCodigoOpt.get().trim();
        String parteNumericaStr = ultimoCodigoStr.substring(3);

        try {
            int ultimoNumero = Integer.parseInt(parteNumericaStr);
            int siguienteNumero = ultimoNumero + 1;
            return String.format("PER%03d", siguienteNumero);
        } catch (NumberFormatException e) {
            return "PER" + String.format("%03d", todos.size() + 1);
        }
    }
}

package ec.edu.monster.servicios;

import ec.edu.monster.entidades.Empleado;
import ec.edu.monster.entidades.Familiar;
import ec.edu.monster.entidades.FamiliarId;
import ec.edu.monster.entidades.Sexo;
import ec.edu.monster.repositorio.EmpleadoRepositorio;
import ec.edu.monster.repositorio.FamiliarRepositorio;
import ec.edu.monster.repositorio.SexoRepositorio;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class FamiliarServicio {

    @Autowired
    private FamiliarRepositorio familiarRepo;

    @Autowired
    private EmpleadoRepositorio empleadoRepo;

    @Autowired
    private SexoRepositorio sexoRepo;

    @Transactional(readOnly = true)
    public List<Familiar> listarPorEmpleado(String empleadoCodigo) {
        List<Familiar> lista = familiarRepo.findByEmpleadoCodigo(empleadoCodigo);
        lista.forEach(f -> {
            if (f.getId().getCodigo() != null) f.getId().setCodigo(f.getId().getCodigo().trim());
            if (f.getId().getCodigoEmpleado() != null) f.getId().setCodigoEmpleado(f.getId().getCodigoEmpleado().trim());
            if (f.getCedula() != null) f.setCedula(f.getCedula().trim());
        });
        return lista;
    }

    @Transactional
    public Familiar guardar(Familiar familiar) {
        Empleado emp = empleadoRepo.findById(familiar.getId().getCodigoEmpleado())
                .orElseThrow(() -> new RuntimeException("Empleado no encontrado"));

        familiar.getId().setCodigo(generarSiguienteCodigo(familiar.getId().getCodigoEmpleado()));
        familiar.setEmpleado(emp);

        if (familiar.getSexo() != null && familiar.getSexo().getCodigo() != null) {
            Sexo s = sexoRepo.findById(familiar.getSexo().getCodigo()).orElse(null);
            familiar.setSexo(s);
        }

        return familiarRepo.save(familiar);
    }

    @Transactional
    public Familiar editar(String empleadoCodigo, String codigo, Familiar datos) {
        FamiliarId id = new FamiliarId();
        id.setCodigoEmpleado(empleadoCodigo);
        id.setCodigo(codigo);

        Familiar fam = familiarRepo.findById(id)
                .orElseThrow(() -> new RuntimeException("Familiar no encontrado"));

        fam.setApellidos(datos.getApellidos());
        fam.setNombres(datos.getNombres());
        fam.setFechaNacimiento(datos.getFechaNacimiento());

        return familiarRepo.save(fam);
    }

    @Transactional
    public void eliminar(String empleadoCodigo, String codigo) {
        FamiliarId id = new FamiliarId();
        id.setCodigoEmpleado(empleadoCodigo);
        id.setCodigo(codigo);

        if (!familiarRepo.existsById(id)) {
            throw new RuntimeException("Familiar no encontrado");
        }
        familiarRepo.deleteById(id);
    }

    private String generarSiguienteCodigo(String empleadoCodigo) {
        String maxCodigo = familiarRepo.findLastCodigoByEmpleado(empleadoCodigo);
        if (maxCodigo == null) return "FAM001";

        String parteNumerica = maxCodigo.trim().substring(3);
        try {
            int siguiente = Integer.parseInt(parteNumerica) + 1;
            return String.format("FAM%03d", siguiente);
        } catch (NumberFormatException e) {
            return "FAM001";
        }
    }
}

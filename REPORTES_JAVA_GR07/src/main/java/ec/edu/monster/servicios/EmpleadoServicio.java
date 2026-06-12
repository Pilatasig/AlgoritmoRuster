package ec.edu.monster.servicios;

import ec.edu.monster.entidades.AsignacionCargo;
import ec.edu.monster.entidades.Empleado;
import ec.edu.monster.entidades.EstadoCivil;
import ec.edu.monster.entidades.Sexo;
import ec.edu.monster.repositorio.EmpleadoRepositorio;
import ec.edu.monster.repositorio.EstadoCivilRepositorio;
import ec.edu.monster.repositorio.SexoRepositorio;
import java.util.Base64;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import java.util.Date;
import java.util.List;
import java.util.Optional;

@Service
public class EmpleadoServicio {

    @Autowired
    private EmpleadoRepositorio empleadoRepo;

    @Autowired
    private EstadoCivilRepositorio estadoCivilRepo;

    @Autowired
    private SexoRepositorio sexoRepo;

    @Transactional(readOnly = true)
    public Empleado obtenerPorCodigo(String codigo) {
        return empleadoRepo.findById(codigo)
                .orElseThrow(() -> new RuntimeException("Empleado no encontrado: " + codigo));
    }

    @Transactional(readOnly = true)
    public List<Empleado> listarTodos() {
        List<Empleado> lista = empleadoRepo.findAll();
        lista.forEach(e -> {
            if (e.getCodigo() != null) e.setCodigo(e.getCodigo().trim());
            if (e.getCedula() != null) e.setCedula(e.getCedula().trim());
        });
        return lista;
    }

    @Transactional
    public Empleado guardar(Empleado empleado, String codigoCargoSeleccionado) {
        // Generar Código Automático si es un registro nuevo
        if (empleado.getCodigo() == null || empleado.getCodigo().trim().isEmpty()) {
            empleado.setCodigo(generarSiguienteCodigo());
        }

        if (empleado.getEstadoCivil() != null && empleado.getEstadoCivil().getCodigo() != null) {
            EstadoCivil ec = estadoCivilRepo.findById(empleado.getEstadoCivil().getCodigo()).orElse(null);
            empleado.setEstadoCivil(ec);
        }

        if (empleado.getSexo() != null && empleado.getSexo().getCodigo() != null) {
            Sexo s = sexoRepo.findById(empleado.getSexo().getCodigo()).orElse(null);
            empleado.setSexo(s);
        }

        if (empleado.getFotoBase64() != null && !empleado.getFotoBase64().isEmpty()) {
            empleado.setFoto(Base64.getDecoder().decode(empleado.getFotoBase64()));
        }

        // Si se envió un cargo desde la pestaña laboral, gestionamos la tabla intermedia
        if (codigoCargoSeleccionado != null && !codigoCargoSeleccionado.isEmpty()) {
            boolean yaTieneEseCargo = empleado.getAsignaciones().stream()
                    .anyMatch(a -> a.getId().getCodigoCargo().equals(codigoCargoSeleccionado));
            
            if (!yaTieneEseCargo) {
                AsignacionCargo nuevaAsignacion = new AsignacionCargo();
                nuevaAsignacion.setEmpleado(empleado);
                nuevaAsignacion.getId().setCodigoEmpleado(empleado.getCodigo());
                nuevaAsignacion.getId().setCodigoCargo(codigoCargoSeleccionado);
                nuevaAsignacion.getId().setFechaInicio(new Date()); // Fecha de hoy como inicio laboral
                
                empleado.getAsignaciones().add(nuevaAsignacion);
            }
        }

        return empleadoRepo.saveAndFlush(empleado);
    }

    @Transactional
    public Empleado editar(String codigo, Empleado datos) {
        Empleado emp = empleadoRepo.findById(codigo)
                .orElseThrow(() -> new RuntimeException("Empleado no encontrado: " + codigo));

        emp.setNombres(datos.getNombres());
        emp.setApellidos(datos.getApellidos());
        emp.setTelefono(datos.getTelefono());
        emp.setCorreo(datos.getCorreo());
        emp.setDireccion(datos.getDireccion());
        emp.setSalario(datos.getSalario());
        emp.setDiscapacidad(datos.isDiscapacidad());

        if (datos.getEstadoCivil() != null && datos.getEstadoCivil().getCodigo() != null) {
            EstadoCivil ec = estadoCivilRepo.findById(datos.getEstadoCivil().getCodigo()).orElse(null);
            emp.setEstadoCivil(ec);
        }

        if (datos.getFotoBase64() != null && !datos.getFotoBase64().isEmpty()) {
            emp.setFoto(Base64.getDecoder().decode(datos.getFotoBase64()));
        }

        return empleadoRepo.save(emp);
    }

    @Transactional
    public void eliminar(String codigo) {
        if (!empleadoRepo.existsById(codigo)) {
            throw new RuntimeException("Empleado no encontrado: " + codigo);
        }
        empleadoRepo.deleteById(codigo);
    }

    private String generarSiguienteCodigo() {
        List<Empleado> todos = empleadoRepo.findAll();
        Optional<String> maxCodigoOpt = todos.stream()
                .map(Empleado::getCodigo)
                .filter(c -> c != null && c.trim().toUpperCase().startsWith("EMP"))
                .max(String::compareTo);

        if (maxCodigoOpt.isEmpty()) return "EMP00001";

        String parteNumerica = maxCodigoOpt.get().trim().substring(3);
        try {
            int siguiente = Integer.parseInt(parteNumerica) + 1;
            return String.format("EMP%05d", siguiente);
        } catch (NumberFormatException e) {
            return "EMP" + String.format("%05d", todos.size() + 1);
        }
    }
}
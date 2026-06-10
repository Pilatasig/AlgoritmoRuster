package ec.edu.monster.config;

import ec.edu.monster.entidades.*;
import ec.edu.monster.repositorio.*;
import jakarta.transaction.Transactional;
import java.util.Date;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Component;

@Component
public class DataInitializer implements CommandLineRunner {

    @Autowired
    private SexoRepositorio sexoRep;

    @Autowired
    private EstadoCivilRepositorio estadoCivilRep;

    @Autowired
    private EstadoRepositorio estadoRep;

    @Autowired
    private DepartamentoRepositorio departamentoRep;

    @Autowired
    private CargoRepositorio cargoRep;

    @Autowired
    private EmpleadoRepositorio empleadoRep;

    @Autowired
    private UsuarioRepositorio usuarioRep;

    @Autowired
    private PerfilRepositorio perfilRep;

    @Autowired
    private PasswordEncoder encoder;

    @Override
    @Transactional
    public void run(String... args) throws Exception {
        if (sexoRep.count() > 0) {
            return;
        }

        Sexo m = new Sexo();
        m.setCodigo("M");
        m.setDescripcion("Masculino");
        sexoRep.save(m);

        Sexo f = new Sexo();
        f.setCodigo("F");
        f.setDescripcion("Femenino");
        sexoRep.save(f);

        String[][] estadosCiviles = {
            {"S", "Soltero(a)"},
            {"C", "Casado(a)"},
            {"V", "Viudo(a)"},
            {"D", "Divorciado(a)"},
            {"U", "Unión Libre"}
        };
        for (String[] ec : estadosCiviles) {
            EstadoCivil e = new EstadoCivil();
            e.setCodigo(ec[0]);
            e.setDescripcion(ec[1]);
            estadoCivilRep.save(e);
        }

        String[][] estadosUsuario = {
            {"A", "Activo"},
            {"I", "Inactivo"}
        };
        for (String[] eu : estadosUsuario) {
            Estado e = new Estado();
            e.setCodigo(eu[0]);
            e.setDescripcion(eu[1]);
            estadoRep.save(e);
        }

        Departamento dep = new Departamento();
        dep.setCodigo("DEP001");
        dep.setNombre("SIS");
        dep.setDescripcion("Sistemas");
        departamentoRep.save(dep);

        Cargo cargo = new Cargo();
        cargo.setCodigo("CAR001");
        cargo.setNombre("ADM");
        cargo.setDescripcion("Administrador del Sistema");
        cargo.setDepartamento(dep);
        cargoRep.save(cargo);

        Empleado admin = new Empleado();
        admin.setCodigo("EMP00001");
        admin.setNombres("Administrador");
        admin.setApellidos("Del Sistema");
        admin.setFechaNacimiento(new Date());
        admin.setDireccion("Matriz");
        admin.setTelefono("0999999999");
        admin.setCorreo("admin@monster.edu.ec");
        admin.setCedula("1722222222");
        admin.setDiscapacidad(false);
        admin.setSalario(800.00f);
        admin.setSexo(m);

        AsignacionCargoId asigId = new AsignacionCargoId();
        asigId.setCodigoEmpleado("EMP00001");
        asigId.setCodigoCargo("CAR001");
        asigId.setFechaInicio(new Date());

        AsignacionCargo asig = new AsignacionCargo();
        asig.setId(asigId);
        asig.setEmpleado(admin);

        admin.getAsignaciones().add(asig);
        admin = empleadoRep.save(admin);

        Perfil perfil = new Perfil();
        perfil.setCodigo("ADMIN");
        perfil.setDescripcion("Administrador");
        perfil.setObservaciones("Perfil con acceso total al sistema");
        perfilRep.save(perfil);

        Estado estadoActivo = estadoRep.findById("A")
                .orElseThrow(() -> new RuntimeException("Estado 'A' no encontrado"));

        Usuario usuario = new Usuario();
        usuario.setId("EMP00001");
        usuario.setPassword(encoder.encode("123456"));
        usuario.setFechaCreacion(new Date());
        usuario.setPieFirma("Administrador del Sistema");
        usuario.setEmpleado(admin);
        usuario.setEstado(estadoActivo);
        usuarioRep.save(usuario);
    }
}

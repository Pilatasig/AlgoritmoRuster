package ec.edu.monster.servicios.jpa;

import ec.edu.monster.entidades.jpa.Empleado;
import ec.edu.monster.entidades.jpa.Estado;
import ec.edu.monster.entidades.jpa.Usuario;
import ec.edu.monster.repositorio.jpa.EmpleadoRepositorio;
import ec.edu.monster.repositorio.jpa.EstadoRepositorio;
import ec.edu.monster.repositorio.jpa.UsuarioRepositorio;
import jakarta.transaction.Transactional;
import java.util.Date;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class SeguridadServicio {
    @Autowired
    private EmpleadoRepositorio empRep;
    
    @Autowired
    private UsuarioRepositorio userRep;
    
    @Autowired
    private EstadoRepositorio estadoRep;
    
    @Autowired
    private PasswordEncoder encoder;
    
    private String generarCodigo(){
        Optional<String> lastCodigoOpt= empRep.findLastCodigo();
        
        if(lastCodigoOpt.isEmpty()||lastCodigoOpt.get()==null)
            return "EMP00001";
        
        String lastCodigo= lastCodigoOpt.get().trim();
        String numeroStr= lastCodigo.substring(3);
        int nextNum= Integer.parseInt(numeroStr)+1;
        return String.format("EMP%05d", nextNum);
    }
    
    @Transactional
    public Usuario registrarUsuario(Empleado empleado, String password, String codigoEstadoInicial){
        String nuevoCodigo= generarCodigo();
        empleado.setCodigo(nuevoCodigo);
        
        Empleado empleadoGuardado= empRep.save(empleado);
        Usuario usuario= new Usuario();
        usuario.setEmpleado(empleadoGuardado);
        
        String passwordEncriptada= encoder.encode(password);
        usuario.setPassword(passwordEncriptada);
        usuario.setFechaCreacion(new Date());
        usuario.setPieFirma("Usuario Autogenerado");
        
        Estado estado= estadoRep.findById(codigoEstadoInicial)
                .orElseThrow(()-> new RuntimeException("El estado "+ codigoEstadoInicial+ " No existe en la BD."));
        usuario.setEstado(estado);
        
        return userRep.save(usuario);
    }

    @Transactional
    public Usuario crearUsuarioParaEmpleado(String empleadoCodigo, String password) {
        Empleado empleado = empRep.findById(empleadoCodigo)
                .orElseThrow(() -> new RuntimeException("Empleado no encontrado: " + empleadoCodigo));

        Optional<Usuario> existente = userRep.findByEmpleadoCodigo(empleadoCodigo);
        if (existente.isPresent()) {
            throw new RuntimeException("El empleado ya tiene un usuario registrado.");
        }

        Usuario usuario = new Usuario();
        usuario.setEmpleado(empleado);
        usuario.setPassword(encoder.encode(password));
        usuario.setFechaCreacion(new Date());
        usuario.setPieFirma("Usuario del Sistema");

        Estado estado = estadoRep.findById("A")
                .orElseThrow(() -> new RuntimeException("Estado 'A' no encontrado"));
        usuario.setEstado(estado);

        return userRep.save(usuario);
    }

    @Transactional
    public void actualizarPassword(String empleadoCodigo, String nuevoPassword) {
        Usuario usuario = userRep.findByEmpleadoCodigo(empleadoCodigo)
                .orElseThrow(() -> new RuntimeException("Usuario no encontrado: " + empleadoCodigo));
        usuario.setPassword(encoder.encode(nuevoPassword));
        usuario.setFechaModificacion(new Date());
        userRep.save(usuario);
    }

    @Transactional
    public void cambiarEstado(String empleadoCodigo, String estadoCodigo) {
        Usuario usuario = userRep.findByEmpleadoCodigo(empleadoCodigo)
                .orElseThrow(() -> new RuntimeException("Usuario no encontrado: " + empleadoCodigo));
        Estado estado = estadoRep.findById(estadoCodigo)
                .orElseThrow(() -> new RuntimeException("Estado no encontrado: " + estadoCodigo));
        usuario.setEstado(estado);
        usuario.setFechaModificacion(new Date());
        userRep.save(usuario);
    }

    public Optional<Usuario> buscarUsuario(String codigoEmpleado) {
        return userRep.findByEmpleadoCodigo(codigoEmpleado.trim());
    }

    public boolean autenticarUsuario(String codigoEmpleado, String passwordPlana){
        Optional<Usuario> usuarioOpt= userRep.findByEmpleadoCodigo(codigoEmpleado.trim());
        if(usuarioOpt.isPresent()){
            Usuario usuario = usuarioOpt.get();
            if (usuario.getEstado() == null || !"A".equals(usuario.getEstado().getCodigo())) {
                return false;
            }
            return encoder.matches(passwordPlana, usuario.getPassword());
        }
        return false;
    }

    public boolean isBloqueado(String codigoEmpleado) {
        Optional<Usuario> opt = userRep.findByEmpleadoCodigo(codigoEmpleado.trim());
        if (opt.isPresent() && opt.get().getBloqueadoHasta() != null) {
            return new Date().before(opt.get().getBloqueadoHasta());
        }
        return false;
    }

    public long segundosRestantesBloqueo(String codigoEmpleado) {
        Optional<Usuario> opt = userRep.findByEmpleadoCodigo(codigoEmpleado.trim());
        if (opt.isPresent() && opt.get().getBloqueadoHasta() != null) {
            long diff = opt.get().getBloqueadoHasta().getTime() - new Date().getTime();
            return Math.max(diff / 1000, 0);
        }
        return 0;
    }

    @Transactional
    public void registrarIntentoFallido(String codigoEmpleado) {
        userRep.findByEmpleadoCodigo(codigoEmpleado.trim()).ifPresent(u -> {
            u.setIntentosFallidos(u.getIntentosFallidos() + 1);
            if (u.getIntentosFallidos() >= 3) {
                u.setBloqueadoHasta(new Date(System.currentTimeMillis() + 60000));
                u.setIntentosFallidos(0);
            }
            userRep.save(u);
        });
    }

    @Transactional
    public void resetearIntentos(String codigoEmpleado) {
        userRep.findByEmpleadoCodigo(codigoEmpleado.trim()).ifPresent(u -> {
            u.setIntentosFallidos(0);
            u.setBloqueadoHasta(null);
            userRep.save(u);
        });
    }
}

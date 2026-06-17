package ec.edu.monster.servicios;

import ec.edu.monster.entidades.Empleado;
import ec.edu.monster.entidades.Estado;
import ec.edu.monster.entidades.Usuario;
import ec.edu.monster.repositorio.EmpleadoRepositorio;
import ec.edu.monster.repositorio.EstadoRepositorio;
import ec.edu.monster.repositorio.UsuarioRepositorio;
import jakarta.transaction.Transactional;
import java.util.Date;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
/**
 *
 * @author Usuario
 */

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
    
    public boolean autenticarUsuario(String codigoEmpleado, String passwordPlana){
        Optional<Usuario> usuarioOpt= userRep.findByEmpleadoCodigo(codigoEmpleado.trim());
        if(usuarioOpt.isPresent()){
            Usuario usuario = usuarioOpt.get();
            return encoder.matches(passwordPlana, usuario.getPassword());
        }
        return false;
    }
    
}

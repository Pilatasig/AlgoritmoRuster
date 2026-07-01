package ec.edu.monster.servicios.jpa;

import ec.edu.monster.entidades.jpa.Perfil;
import ec.edu.monster.entidades.jpa.Usuario;
import ec.edu.monster.entidades.jpa.Usuper;
import ec.edu.monster.repositorio.jpa.PerfilRepositorio;
import ec.edu.monster.repositorio.jpa.UsuarioRepositorio;
import ec.edu.monster.repositorio.jpa.UsuperRepositorio;
import java.util.Date;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class AsignarPerfilServicio {

    @Autowired
    private UsuperRepositorio usuperRepo;

    @Autowired
    private PerfilRepositorio perfilRepo;

    @Autowired
    private UsuarioRepositorio usuarioRepo;

    @Transactional(readOnly = true)
    public List<Usuper> listarAsignados(String perfilCodigo) {
        return usuperRepo.findByPerfilCodigoWithUsuarioEmpleado(perfilCodigo.toUpperCase().trim());
    }

    @Transactional(readOnly = true)
    public List<Usuario> listarDisponibles(String perfilCodigo) {
        return usuarioRepo.findUsuariosNotInPerfil(perfilCodigo.toUpperCase().trim());
    }

    @Transactional
    public void asignarUsuario(String perfilCodigo, String usuarioId) {
        String codigoLimpio = perfilCodigo.toUpperCase().trim();
        String usuarioLimpio = usuarioId.trim();

        boolean yaExiste = usuperRepo.findByPerfilCodigoAndUsuarioId(codigoLimpio, usuarioLimpio).isPresent();
        if (yaExiste) {
            throw new RuntimeException("El usuario ya tiene asignado este perfil.");
        }

        Perfil perfil = perfilRepo.findById(codigoLimpio)
                .orElseThrow(() -> new RuntimeException("Perfil no encontrado: " + codigoLimpio));
        Usuario usuario = usuarioRepo.findById(usuarioLimpio)
                .orElseThrow(() -> new RuntimeException("Usuario no encontrado: " + usuarioLimpio));

        Usuper usuper = new Usuper();
        usuper.setPerfil(perfil);
        usuper.setUsuario(usuario);
        usuper.setFechaAsignacion(new Date());

        usuperRepo.saveAndFlush(usuper);
    }

    @Transactional
    public void removerUsuario(String perfilCodigo, String usuarioId) {
        String codigoLimpio = perfilCodigo.toUpperCase().trim();
        String usuarioLimpio = usuarioId.trim();

        Usuper usuper = usuperRepo.findByPerfilCodigoAndUsuarioId(codigoLimpio, usuarioLimpio)
                .orElseThrow(() -> new RuntimeException("La asignación no existe."));

        usuperRepo.delete(usuper);
    }
}

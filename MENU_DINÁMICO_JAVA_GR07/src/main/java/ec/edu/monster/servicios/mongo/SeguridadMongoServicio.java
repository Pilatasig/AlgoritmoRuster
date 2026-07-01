package ec.edu.monster.servicios.mongo;

import ec.edu.monster.entidades.mongo.UsuarioEmpleadoDocumento;
import ec.edu.monster.repositorio.mongo.UsuarioEmpleadoRepositorio;
import java.util.Date;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

//@Service
public class SeguridadMongoServicio {

    @Autowired
    private UsuarioEmpleadoRepositorio usuarioRepo;

    @Autowired
    private PasswordEncoder encoder;

    public Optional<UsuarioEmpleadoDocumento> buscarUsuario(String username) {
        return usuarioRepo.findByUsername(username.trim());
    }

    public boolean autenticarUsuario(String username, String passwordPlana) {
        Optional<UsuarioEmpleadoDocumento> usuarioOpt = usuarioRepo.findByUsername(username.trim());
        if (usuarioOpt.isPresent()) {
            return encoder.matches(passwordPlana, usuarioOpt.get().getPassword());
        }
        return false;
    }

    public boolean isBloqueado(String username) {
        Optional<UsuarioEmpleadoDocumento> opt = usuarioRepo.findByUsername(username.trim());
        if (opt.isPresent() && opt.get().getBloqueadoHasta() != null) {
            return new Date().before(opt.get().getBloqueadoHasta());
        }
        return false;
    }

    public long segundosRestantesBloqueo(String username) {
        Optional<UsuarioEmpleadoDocumento> opt = usuarioRepo.findByUsername(username.trim());
        if (opt.isPresent() && opt.get().getBloqueadoHasta() != null) {
            long diff = opt.get().getBloqueadoHasta().getTime() - new Date().getTime();
            return Math.max(diff / 1000, 0);
        }
        return 0;
    }

    public void registrarIntentoFallido(String username) {
        usuarioRepo.findByUsername(username.trim()).ifPresent(u -> {
            u.setIntentosFallidos(u.getIntentosFallidos() + 1);
            if (u.getIntentosFallidos() >= 3) {
                u.setBloqueadoHasta(new Date(System.currentTimeMillis() + 60000));
                u.setIntentosFallidos(0);
            }
            usuarioRepo.save(u);
        });
    }

    public void resetearIntentos(String username) {
        usuarioRepo.findByUsername(username.trim()).ifPresent(u -> {
            u.setIntentosFallidos(0);
            u.setBloqueadoHasta(null);
            usuarioRepo.save(u);
        });
    }
}

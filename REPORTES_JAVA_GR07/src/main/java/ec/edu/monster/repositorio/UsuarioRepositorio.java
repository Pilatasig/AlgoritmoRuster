package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Usuario;
import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface UsuarioRepositorio extends JpaRepository<Usuario, String>{
    Optional<Usuario> findByEmpleadoCodigo(String empleadoCodigo);
}

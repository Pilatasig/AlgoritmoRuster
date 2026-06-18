package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Perfil;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface PerfilRepositorio extends JpaRepository<Perfil, String>{
    
}

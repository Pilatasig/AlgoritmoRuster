package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Usuper;
import ec.edu.monster.entidades.UsuperId;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface UsuperRepositorio extends JpaRepository<Usuper, UsuperId> {
    
}

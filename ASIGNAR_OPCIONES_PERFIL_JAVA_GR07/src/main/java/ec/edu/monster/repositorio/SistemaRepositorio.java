package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Sistema;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface SistemaRepositorio extends JpaRepository<Sistema, String>{
    
}

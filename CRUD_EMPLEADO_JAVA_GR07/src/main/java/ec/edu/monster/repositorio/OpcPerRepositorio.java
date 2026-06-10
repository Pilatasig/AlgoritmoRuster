package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.OpcPer;
import ec.edu.monster.entidades.OpcPerId;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface OpcPerRepositorio extends JpaRepository<OpcPer, OpcPerId>{
    
}

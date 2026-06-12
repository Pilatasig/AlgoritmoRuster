package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Cargo;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */

@Repository
public interface CargoRepositorio extends JpaRepository<Cargo, String>{
    
}

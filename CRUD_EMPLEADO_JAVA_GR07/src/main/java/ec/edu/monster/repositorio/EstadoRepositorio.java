package ec.edu.monster.repositorio;

/**
 *
 * @author Usuario
 */

import ec.edu.monster.entidades.Estado;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EstadoRepositorio extends JpaRepository<Estado, String> {

}

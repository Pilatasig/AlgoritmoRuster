package ec.edu.monster.repositorio.jpa;

/**
 *
 * @author Usuario
 */

import ec.edu.monster.entidades.jpa.Estado;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EstadoRepositorio extends JpaRepository<Estado, String> {

}

package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Opcion;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface OpcionRepositorio extends JpaRepository<Opcion, String>{
    List<Opcion> findBySistemaCodigo(String sistemaCodigo);
}

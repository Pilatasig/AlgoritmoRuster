package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Empleado;
import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface EmpleadoRepositorio extends JpaRepository<Empleado, String>{
    @Query("SELECT MAX(e.codigo) FROM Empleado e")
    Optional<String> findLastCodigo();

    boolean existsByCedula(String cedula);
}

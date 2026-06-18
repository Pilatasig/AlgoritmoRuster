package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Cargo;
import java.util.List;
import java.util.Optional;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface CargoRepositorio extends JpaRepository<Cargo, String> {

    @Query("SELECT DISTINCT c FROM Cargo c LEFT JOIN FETCH c.asignaciones")
    List<Cargo> findAllWithAsignaciones();

    @Query("SELECT c FROM Cargo c WHERE c.codigo = ?1")
    Optional<Cargo> findByIdCodigo(String codigo);
}

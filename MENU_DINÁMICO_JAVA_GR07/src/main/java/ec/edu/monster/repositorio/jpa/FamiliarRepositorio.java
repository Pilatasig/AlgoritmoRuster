package ec.edu.monster.repositorio.jpa;

import ec.edu.monster.entidades.jpa.Familiar;
import ec.edu.monster.entidades.jpa.FamiliarId;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface FamiliarRepositorio extends JpaRepository<Familiar, FamiliarId> {

    List<Familiar> findByEmpleadoCodigo(String empleadoCodigo);

    boolean existsByCedula(String cedula);

    @Query("SELECT MAX(f.id.codigo) FROM Familiar f WHERE f.id.codigoEmpleado = ?1")
    String findLastCodigoByEmpleado(String empleadoCodigo);
}

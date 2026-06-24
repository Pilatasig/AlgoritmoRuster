package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Opcion;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface OpcionRepositorio extends JpaRepository<Opcion, String>{
    List<Opcion> findBySistemaCodigo(String sistemaCodigo);

    @Query("SELECT DISTINCT o FROM Opcion o "
         + "LEFT JOIN FETCH o.sistema "
         + "WHERE o.sistema.codigo = ?1 AND o.padre IS NULL")
    List<Opcion> findPadresBySistemaCodigo(String sistemaCodigo);

    @Query("SELECT DISTINCT o FROM Opcion o "
         + "LEFT JOIN FETCH o.padre "
         + "WHERE o.padre.codigo = ?1")
    List<Opcion> findByPadreCodigo(String padreCodigo);
}
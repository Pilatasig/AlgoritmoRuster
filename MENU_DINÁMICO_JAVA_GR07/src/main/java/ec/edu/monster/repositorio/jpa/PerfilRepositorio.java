package ec.edu.monster.repositorio.jpa;

import ec.edu.monster.entidades.jpa.Perfil;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 *
 * @author Usuario
 */
@Repository
public interface PerfilRepositorio extends JpaRepository<Perfil, String>{
    
}

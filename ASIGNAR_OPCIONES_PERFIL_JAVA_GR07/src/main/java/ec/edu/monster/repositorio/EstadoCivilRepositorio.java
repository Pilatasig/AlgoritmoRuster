package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.EstadoCivil;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EstadoCivilRepositorio extends JpaRepository<EstadoCivil, String> {
    
}

package ec.edu.monster.repositorio.jpa;

import ec.edu.monster.entidades.jpa.EstadoCivil;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EstadoCivilRepositorio extends JpaRepository<EstadoCivil, String> {
    
}

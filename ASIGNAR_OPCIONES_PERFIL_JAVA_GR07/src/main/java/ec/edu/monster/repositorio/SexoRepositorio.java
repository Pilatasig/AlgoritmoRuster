package ec.edu.monster.repositorio;

import ec.edu.monster.entidades.Sexo;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface SexoRepositorio extends JpaRepository<Sexo, String> {
    
}

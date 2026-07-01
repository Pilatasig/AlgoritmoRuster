package ec.edu.monster.config;

import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

/**
 *
 * @author Usuario
 */
@Configuration
@EnableJpaRepositories(basePackages = "ec.edu.monster.repositorio.jpa")
@EntityScan(basePackages = "ec.edu.monster.entidades.jpa")
public class JpaConfig {
    
}

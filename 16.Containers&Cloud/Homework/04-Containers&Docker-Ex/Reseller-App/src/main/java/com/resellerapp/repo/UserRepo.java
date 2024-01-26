package com.resellerapp.repo;

import com.resellerapp.model.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;
import java.util.Set;

@Repository
public interface UserRepo extends JpaRepository<User, Long> {

    Optional<User> findByUsername(String username);

    Optional<User> findByEmail(String email);

    Set<User> findAllByIdIsNot(Long id);

    Optional<User> findUserByOffers_Id(Long offers_id);
}

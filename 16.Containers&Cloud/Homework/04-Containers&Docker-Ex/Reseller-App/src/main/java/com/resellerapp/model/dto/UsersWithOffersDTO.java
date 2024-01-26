package com.resellerapp.model.dto;

import java.util.HashSet;
import java.util.Set;

public class UsersWithOffersDTO {
    private String username;
    private Long id;
    private Set<OfferDTO> offers;

    public UsersWithOffersDTO() {
        this.offers = new HashSet<>();
    }

    public String getUsername() {
        return username;
    }

    public UsersWithOffersDTO setUsername(String username) {
        this.username = username;
        return this;
    }

    public Long getId() {
        return id;
    }

    public UsersWithOffersDTO setId(Long id) {
        this.id = id;
        return this;
    }

    public Set<OfferDTO> getOffers() {
        return offers;
    }

    public UsersWithOffersDTO setOffers(Set<OfferDTO> offers) {
        this.offers = offers;
        return this;
    }

//    public Set<User> getUserLikes() {
//        return userLikes;
//    }
//
//    public OffersWithUsernamesDTO setUserLikes(Set<User> userLikes) {
//        this.userLikes = userLikes;
//        return this;
//    }

//    public boolean checkIfUserIdMatchId(Long userId){
//        return this.getUserLikes().stream()
//                .anyMatch(user -> {
//                    boolean r = user.getId().equals(userId);
//                    return r;
//                });
//    }
}

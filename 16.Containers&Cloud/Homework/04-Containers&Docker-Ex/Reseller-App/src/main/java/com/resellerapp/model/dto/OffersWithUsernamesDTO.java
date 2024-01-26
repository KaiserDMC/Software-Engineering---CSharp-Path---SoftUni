package com.resellerapp.model.dto;

import com.resellerapp.model.entity.ConditionEnum;

public class OffersWithUsernamesDTO {
    private String description;
    private ConditionEnum condition;
    private String username;
    private Double price;
    private Long id;
//    private Set<User> userLikes;

    public OffersWithUsernamesDTO() {
    }

    public String getDescription() {
        return description;
    }

    public OffersWithUsernamesDTO setDescription(String description) {
        this.description = description;
        return this;
    }

    public ConditionEnum getCondition() {
        return condition;
    }

    public OffersWithUsernamesDTO setCondition(ConditionEnum condition) {
        this.condition = condition;
        return this;
    }

    public String getUsername() {
        return username;
    }

    public OffersWithUsernamesDTO setUsername(String username) {
        this.username = username;
        return this;
    }

    public Double getPrice() {
        return price;
    }

    public OffersWithUsernamesDTO setPrice(Double price) {
        this.price = price;
        return this;
    }

    public Long getId() {
        return id;
    }

    public OffersWithUsernamesDTO setId(Long id) {
        this.id = id;
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

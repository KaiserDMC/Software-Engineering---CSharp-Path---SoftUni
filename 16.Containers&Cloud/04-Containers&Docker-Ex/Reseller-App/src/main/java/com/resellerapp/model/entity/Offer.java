package com.resellerapp.model.entity;

import javax.persistence.*;

@Entity
@Table(name = "offers")
public class Offer extends BaseEntity {

    @Column(columnDefinition = "TEXT")
    private String description;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "conditions_id")
    private Condition condition;

    @Column
    private Double price;

//    @ManyToOne
//    @JoinColumn(name = "user_id")
//    private User user;
//
//    public User getUser() {
//        return user;
//    }
//
//    public Offer setUser(User user) {
//        this.user = user;
//        return this;
//    }


    public Offer() {
    }

    public String getDescription() {
        return description;
    }

    public Offer setDescription(String content) {
        this.description = content;
        return this;
    }

    public Condition getCondition() {
        return condition;
    }

    public Offer setCondition(Condition condition) {
        this.condition = condition;
        return this;
    }



    public Double getPrice() {
        return price;
    }

    public Offer setPrice(Double price) {
        this.price = price;
        return this;
    }
}

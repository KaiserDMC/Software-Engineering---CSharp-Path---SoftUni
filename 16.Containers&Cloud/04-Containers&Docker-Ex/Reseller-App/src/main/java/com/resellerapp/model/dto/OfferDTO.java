package com.resellerapp.model.dto;

import com.resellerapp.model.entity.ConditionEnum;

public class OfferDTO {
    private Long id;

    private String description;

    private ConditionEnum condition;

    private Double price;

    public OfferDTO() {
    }

    public Long getId() {
        return id;
    }

    public OfferDTO setId(Long id) {
        this.id = id;
        return this;
    }

    public String getDescription() {
        return description;
    }

    public OfferDTO setDescription(String description) {
        this.description = description;
        return this;
    }

    public ConditionEnum getCondition() {
        return condition;
    }

    public OfferDTO setCondition(ConditionEnum condition) {
        this.condition = condition;
        return this;
    }

    public Double getPrice() {
        return price;
    }

    public OfferDTO setPrice(Double price) {
        this.price = price;
        return this;
    }
}

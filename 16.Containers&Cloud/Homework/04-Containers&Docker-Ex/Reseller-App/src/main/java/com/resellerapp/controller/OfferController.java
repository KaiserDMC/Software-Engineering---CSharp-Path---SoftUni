package com.resellerapp.controller;

import com.resellerapp.model.dto.AddOfferDTO;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.validation.Valid;

@RequestMapping("/offers")
public interface OfferController {

    @GetMapping("/add-offer")
    String addOffer();

    @PostMapping("/add-offer")
    String addOffer(@Valid AddOfferDTO addOfferDTO, BindingResult result, RedirectAttributes redirectAttributes);

    @GetMapping("/buy-offer/{id}")
    String buyOffer(@PathVariable Long id);

    @GetMapping("/remove/{id}")
    String removeOffer(@PathVariable Long id);
}


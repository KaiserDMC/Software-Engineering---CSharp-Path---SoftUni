package com.resellerapp.controller;

import com.resellerapp.model.dto.AddOfferDTO;
import com.resellerapp.service.OfferServiceImpl;
import com.resellerapp.util.LoggedUser;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

@Controller
public class OfferControllerImpl implements OfferController {

    private final LoggedUser loggedUser;
    private final OfferServiceImpl offerService;

    public OfferControllerImpl(LoggedUser loggedUser, OfferServiceImpl offerService) {
        this.loggedUser = loggedUser;
        this.offerService = offerService;
    }

    @Override
    public String addOffer() {
        if (!loggedUser.isLogged()) {
            return "redirect:/users/login";
        }

        return "offer-add";
    }

    @Override
    public String addOffer(AddOfferDTO addOfferDTO, BindingResult result, RedirectAttributes redirectAttributes) {
        if (result.hasErrors()) {
            redirectAttributes
                    .addFlashAttribute("addOfferDTO", addOfferDTO)
                    .addFlashAttribute("org.springframework.validation.BindingResult.addOfferDTO", result);

            return "redirect:/offers/add-offer";
        }

        this.offerService.addOffer(addOfferDTO,loggedUser.getId());
        return "redirect:/home";
    }

    @Override
    public String buyOffer(Long id) {
        offerService.buyOfferWithId(id, loggedUser.getId());
        return "redirect:/home";
    }

    @Override
    public String removeOffer(Long id) {
        offerService.removeOfferById(id,loggedUser.getId());

        return "redirect:/home";
    }

    @ModelAttribute
    public AddOfferDTO addOfferDTO() {
        return new AddOfferDTO();
    }
}

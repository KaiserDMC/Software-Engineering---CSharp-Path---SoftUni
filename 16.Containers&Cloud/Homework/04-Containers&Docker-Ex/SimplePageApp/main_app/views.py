from django.shortcuts import render


# Create your views here.
def home(request):
    context = {
        'email': 'contact@example.com',
        'phone': '123-456-7890',
    }
    return render(request, 'home-page.html', context)

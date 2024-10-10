const weatherApiKey = "4ea1e952c7840c5fe57588afc58a26de";
const weatherApiUrl = `https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API KEY}&units=metric`;

const galleryImages = [
    {
        src: "assets/gallery/image1.jpg",
        alt: "Thumbnail Image 1"
    },
    {
        src: "assets/gallery/image2.jpg",
        alt: "Thumbnail Image 2"
    },
    {
        src: "assets/gallery/image3.jpg",
        alt: "Thumbnail Image 3"
    }
];

function menuHandler(){
    document.querySelector('#open-nav-menu').addEventListener('click', ()=>{
        document.querySelector("header nav .wrapper").classList.toggle('nav-open');
    });
    
    document.querySelector('#close-nav-menu').addEventListener('click', ()=>{
        document.querySelector("header nav .wrapper").classList.toggle('nav-open');
    });
}

function celciusToFahr(temperature)
{
    let fahr = (temperature * 9/5) + 32;
    return fahr;
}
function greetingHandler(){
    let greetingText;
    let currentHour = new Date().getHours();
    if(currentHour < 12){
        greetingText = "Good morning!";
    } else if(currentHour < 19){
        greetingText = "Good afternoon!";
    } else if (currentHour < 24){
        greetingText = "Good evening!";
    } else {
        greetingText = "Welcome";
    }
    document.querySelector("#greeting").innerHTML = greetingText;   

}

function clockHandler(){
    setInterval(()=>{
        let localTime = new Date();
    
        document.querySelector("span[data-time=hours]").textContent = localTime.getHours().toString().padStart(2, '0');
        document.querySelector("span[data-time=minutes]").textContent = localTime.getMinutes().toString().padStart(2, '0');
        document.querySelector("span[data-time=seconds]").textContent = localTime.getSeconds().toString().padStart(2, '0');
    },1000);
}

function galleryHandler(){
    let mainImage = document.querySelector("#gallery > img");
    let thumbnails = document.querySelector("#gallery .thumbnails");
    
    mainImage.src = galleryImages[0].src;
    mainImage.alt = galleryImages[0].alt;
    
    galleryImages.forEach((image, index)=>{
        let thumb = document.createElement("img");
        thumb.src = image.src;
        thumb.alt = image.alt;
        thumb.dataset.arrayIndex = index;
        thumb.dataset.selected = index === 0 ? true : false;
    
        thumb.addEventListener("click", e=>{
            let selectedIndex = e.target.dataset.arrayIndex;
            let selectedImage = galleryImages[selectedIndex];
            mainImage.src = selectedImage.src;
            mainImage.alt = selectedImage.alt;
    
            thumbnails.querySelectorAll("img").forEach(function(img){
                img.dataset.selected = false;
            });
    
            e.target.dataset.selected = true;
        });
    
        thumbnails.appendChild(thumb);
    });
}

function productsHandler(){
    fetch('/api/products')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            products = data;
            let freeProducts = products.filter(product => !product.price || product.price <= 0);
            let paidProducts = products.filter(product => product.price > 0);

            populateProducts(products);
            document.querySelector(".products-filter label[for=all] span.product-amount").textContent = products.length;
            document.querySelector(".products-filter label[for=paid] span.product-amount").textContent = paidProducts.length;
            document.querySelector(".products-filter label[for=free] span.product-amount").textContent = freeProducts.length;

            let productsFilter = document.querySelector(".products-filter");
            productsFilter.addEventListener("click", e => {
                if (e.target.id === "all") {
                    populateProducts(products);
                } else if (e.target.id === "paid") {
                    populateProducts(paidProducts);
                } else if (e.target.id === "free") {
                    populateProducts(freeProducts);
                }
            });
        })
        .catch(error => console.error('There has been a problem with your fetch operation:', error));
}

function populateProducts(productList){
    let productsSection = document.querySelector(".products-area");
    productsSection.textContent = "";
    productList.forEach(function(product, index){
        let productElm = document.createElement("div");
        productElm.classList.add("product-item");
        let productImage = document.createElement("img");
        
        productImage.src = product.imageUrl;
        productImage.alt = "Image for " + product.title;

        let productDetails = document.createElement("div");
        productDetails.classList.add("product-details");

        let productTitle = document.createElement("h3");
        productTitle.classList.add("product-title");
        productTitle.textContent = product.title;

        let productAuthor = document.createElement("p");
        productAuthor.classList.add("product-author");
        productAuthor.textContent = product.author;

        let priceTitle = document.createElement("p");
        priceTitle.classList.add("price-title");
        priceTitle.textContent = "Price";

        let productPrice = document.createElement("p");
        productPrice.classList.add("product-price");
        productPrice.textContent = product.price > 0 ?"$" + product.price.toFixed(2) : "Free";

        productDetails.append(productTitle);
        productDetails.append(productAuthor);
        productDetails.append(priceTitle);
        productDetails.append(productPrice);


        productElm.append(productImage);
        productElm.append(productDetails);

        productsSection.append(productElm);
    });
}

function footerHandler(){
    let currentYear = new Date().getFullYear();
    document.querySelector("footer").textContent = `© ${currentYear} - All rights reserved`;
}

function weatherHandler(){
    navigator.geolocation.getCurrentPosition(function(position){
        let latitude = position.coords.latitude;
        let longitude = position.coords.longitude;
        let url = weatherApiUrl
        .replace("{lat}",latitude)
        .replace("{lon}",longitude)
        .replace("{API KEY}",weatherApiKey);
        fetch(url)
        .then(response => response.json())
        .then(data => {
            const condition = data.weather[0].description;
            const location = data.name
            const temperature = data.main.temp;

            let celsiusText = `The weather is ${condition} in ${location} and it's ${temperature.toString()}°C outside.`;
            let fahrText = `The weather is ${condition} in ${location} and it's ${celciusToFahr(temperature).toString()}°F outside.`;
            
            document.querySelector("p#weather").innerHTML = celsiusText;
            
            document.querySelector(".weather-group").addEventListener('click',e=>{
                if(e.target.id == "celsius"){
                    document.querySelector("p#weather").innerHTML = celsiusText;
                }
                else if(e.target.id == "fahr"){
                    document.querySelector("p#weather").innerHTML = fahrText;
                }
            });
        })
        .catch(data => console.log(data));


    });
}

menuHandler();
greetingHandler();
weatherHandler();
clockHandler();
galleryHandler();
productsHandler();
footerHandler();
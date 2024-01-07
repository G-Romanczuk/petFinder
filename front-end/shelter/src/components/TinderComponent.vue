<template>
    <div class="tinder">
        <div class="tinder--status">
            <i class="fa fa-remove"> <img src="@/assets/broken.png" alt="" style="position: relative; z-index: -1;  right: 40vw;" ></i>
            <i class="fa fa-heart"> <img src="@/assets/pinkheart.png" alt="" style="position: relative; z-index: -1;  left: 40vw;"></i>
        </div>

        <div class="tinder--cards">
            <div v-for="(id, i) in animalsStore.pets" class="tinder--card">

                        <img v-bind:src="animalsStore.pets[i].images[0]"
                            style=" border-radius: 10px; height: 100%; width: 100%;  margin: 0;  border: 1px solid rgb(143, 83, 122);  "
                            cover>

                           

                            <div
                                style="position: absolute; bottom: 10px; left: 10px; width: fit-content; height: fit-content; padding-bottom: 10px; background-color:  rgba(255, 255, 255, 0.8); margin-top: auto;">
                              <v-row>
                               
                                <p class="title" style="text-align: left; color:  rgb(143, 83, 122); text-shadow:none;">
                                   
                                    {{ animalsStore.pets[i].name }},
                                <div style="font-size: medium; display: inline"
                                    v-if="(animalsStore.pets[i].shelterModel.name != '')"> {{
                                        animalsStore.pets[i].shelterModel.name }}   </div>
                                </p>  
                                <TinderPetsComponent :pet="animalsStore.pets[i]" :index="i" />
                            </v-row>
                                <v-row
                                    style="width: fit-content; margin: 1vh auto 0 0; border-bottom:2px solid darkgray ; font-size: small; ">

                                    <v-row style=" width: fit-content; margin: 0.5vh"
                                        v-if="(animalsStore.pets[i].vaccination == 'Tak')">
                                        <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Szczepiony/a:
                                        </div>
                                        <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                                icon="mdi-check-circle"></v-icon></div>
                                    </v-row>
                                    <v-row style=" width: fit-content; margin: 0.5vh"
                                        v-if="(animalsStore.pets[i].castration == 'Tak')">
                                        <div style="width: fit-content; border-radius: 7px; margin: 2px;">
                                            Kastracja/Sterylizacja: </div>
                                        <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                                icon="mdi-check-circle"></v-icon></div>
                                    </v-row>
                                    <v-row style=" width: fit-content; margin: 0.5vh"
                                        v-if="(animalsStore.pets[i].childFriendly == 'Tak')">
                                        <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje dzieci:
                                        </div>
                                        <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                                icon="mdi-check-circle"></v-icon></div>
                                    </v-row>
                                    <v-row style=" width: fit-content; margin: 0.5vh"
                                        v-if="(animalsStore.pets[i].basicTraining == 'Tak')">
                                        <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Tresowany: </div>
                                        <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                                icon="mdi-check-circle"></v-icon></div>
                                    </v-row>
                                    <v-row style=" width: fit-content; margin: 0.5vh"
                                        v-if="(animalsStore.pets[i].otherDogs == 'Tak')">
                                        <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje psy:
                                        </div>
                                        <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                                icon="mdi-check-circle"></v-icon></div>
                                    </v-row>
                                    <v-row style=" width: fit-content; margin: 0.5vh"
                                        v-if="(animalsStore.pets[i].otherCats == 'Tak')">
                                        <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje koty:
                                        </div>
                                        <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                                icon="mdi-check-circle"></v-icon></div>
                                    </v-row>
                                    <v-row style=" width: fit-content; margin: 0.5vh"
                                        v-if="(animalsStore.pets[i].cuddly == 'Tak')">
                                        <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Czuły: </div>
                                        <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                                icon="mdi-check-circle"></v-icon></div>
                                    </v-row>
                                </v-row>
                               
                            </div>

                           
                       
       
            </div>
        </div>
        <div class="tinder--buttons">
            <button id="nope"  ><i class="fa fa-remove">  <img src="@/assets/broken.png" alt="" style="width: 50px; position: relative; top: 1vh;  " >  </i></button>
            <button id="love" ><i class="fa fa-heart">  <img src="@/assets/pinkheart.png" alt="" style="width: 50px; position: relative; top: 1vh;" ></i></button>
        </div>
    </div>
</template>

<script setup lang="js">
import { onMounted, ref } from 'vue'
import { useUserStore } from '@/store/user';
import { useAnimalsStore } from '@/store/animals';
import TinderPetsComponent from './TinderPetsComponent.vue';
import * as Hammer from 'hammerjs'
const userStore = useUserStore();
const animalsStore = useAnimalsStore()
animalsStore.getPets();
var dialog = ref(false)
var show = ref(false)



onMounted(() => {
    'use strict';

    var tinderContainer = document.querySelector('.tinder');
    var allCards = document.querySelectorAll('.tinder--card');
    var nope = document.getElementById('nope');
    var love = document.getElementById('love');

    function initCards(card, index) {
        var newCards = document.querySelectorAll('.tinder--card:not(.removed)');

        newCards.forEach(function (card, index) {
            card.style.zIndex = allCards.length - index;
            card.style.transform = 'scale(' + (20 - index) / 20 + ') translateY(-' + 30 * index + 'px)';
            card.style.opacity = (10 - index) / 10;
        });

        tinderContainer.classList.add('loaded');
    }

    initCards();

    allCards.forEach(function (el) {
        var hammertime = new Hammer(el);

        hammertime.on('pan', function (event) {
            el.classList.add('moving');
        });

        hammertime.on('pan', function (event) {
            if (event.deltaX === 0) return;
            if (event.center.x === 0 && event.center.y === 0) return;

            tinderContainer.classList.toggle('tinder_love', event.deltaX > 0);
            tinderContainer.classList.toggle('tinder_nope', event.deltaX < 0);

            var xMulti = event.deltaX * 0.03;
            var yMulti = event.deltaY / 80;
            var rotate = xMulti * yMulti;

            event.target.style.transform = 'translate(' + event.deltaX + 'px, ' + event.deltaY + 'px) rotate(' + rotate + 'deg)';
        });

        hammertime.on('panend', function (event) {
            el.classList.remove('moving');
            tinderContainer.classList.remove('tinder_love');
            tinderContainer.classList.remove('tinder_nope');

            var moveOutWidth = document.body.clientWidth;
            var keep = Math.abs(event.deltaX) < 80 || Math.abs(event.velocityX) < 0.5;

            event.target.classList.toggle('removed', !keep);

            if (keep) {
                event.target.style.transform = '';
            } else {
                var endX = Math.max(Math.abs(event.velocityX) * moveOutWidth, moveOutWidth);
                var toX = event.deltaX > 0 ? endX : -endX;
                var endY = Math.abs(event.velocityY) * moveOutWidth;
                var toY = event.deltaY > 0 ? endY : -endY;
                var xMulti = event.deltaX * 0.03;
                var yMulti = event.deltaY / 80;
                var rotate = xMulti * yMulti;

                event.target.style.transform = 'translate(' + toX + 'px, ' + (toY + event.deltaY) + 'px) rotate(' + rotate + 'deg)';
                initCards();

                //TUTAJ OPUSZA
            }
        });
    });

    function createButtonListener(love) {
        return function (event) {
            var cards = document.querySelectorAll('.tinder--card:not(.removed)');
            var moveOutWidth = document.body.clientWidth * 1.5;

            if (!cards.length) return false;

            var card = cards[0];

            card.classList.add('removed');

            if (love) {
                card.style.transform = 'translate(' + moveOutWidth + 'px, -100px) rotate(-30deg)';
            } else {
                card.style.transform = 'translate(-' + moveOutWidth + 'px, -100px) rotate(30deg)';
            }

            initCards();

            event.preventDefault();
        };
    }

    var nopeListener = createButtonListener(false);
    var loveListener = createButtonListener(true);

    nope.addEventListener('click', nopeListener);
    love.addEventListener('click', loveListener);
});






</script>

<style lang="css">
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');




.shelterText {
    font-family: 'Gruppo', sans-serif;
    font-size: large;
    font-weight: 900;
    display: block;
    padding: 5px;
}


.center-text {
    text-align: center;
}


.scale :hover {
    transform: scale(1.1);
}

.dontscale :hover {
    transform: scale(1);
}

.title {
    font-family: 'Gruppo', sans-serif;
    font-size: x-large;
    font-weight: bolder;
    font-stretch: wider;
    color: white;
}

.little-title {
    font-family: 'Gruppo', sans-serif;
    font-weight: bold;
    font-size: medium;
    color: rgb(175, 126, 158);
    text-shadow: 1px 2px 2px #000000
}


.scrollbar::-webkit-scrollbar-track {
    -webkit-box-shadow: inset 0 0 0px rgba(0, 0, 0, 0.3);
    background-color: transparent;
    border-radius: 10px;
}

.scrollbar::-webkit-scrollbar {
    display: block;
    width: 15px;
}

.scrollbar::-webkit-scrollbar-thumb {
    border-radius: 10px;
    background-image: -webkit-gradient(linear,
            left bottom,
            left top,
            color-stop(0.14, rgb(235, 196, 222)),
            color-stop(0.24, rgb(221, 167, 202)),
            color-stop(0.52, rgb(175, 126, 158)),
            color-stop(0.86, rgb(131, 70, 109)));
}

.scrollbar::-webkit-scrollbar-track-piece:end {
    background: transparent;
    margin-bottom: 3vh;
}

.scrollbar::-webkit-scrollbar-track-piece:start {
    background: transparent;
    margin-top: 3vh;
}


.reveal {
    position: relative;
    opacity: 0;
}

.reveal.active {
    opacity: 1;
}

.slide-left {
    animation: slide-left 3s ease 1s 1 normal forwards;
}

.slide-right {
    animation: slide-right 3s ease 1s 1 normal forwards;
}

@keyframes slide-left {
    0% {
        opacity: 1;
        transform: translateX(0);
    }

    100% {
        opacity: 0;
        transform: translateX(300px);
    }
}


@keyframes slide-right {
    0% {
        opacity: 1;
        transform: translateX(0);
    }

    100% {
        opacity: 0;
        transform: translateX(-300px);
    }
}

@keyframes fade-left {
    0% {
        transform: translateX(0);
        opacity: 1;
    }

    100% {
        transform: translateX(2000px);
        opacity: 1;
    }
}


.fade-in-out {
    opacity: 0;
    animation: fade-out 3s ease-out forwards;
}

.fade-out {
    animation: fade-out 2s ease-out 2.5s 1 normal forwards;
}


@keyframes fade-out {
    0% {

        opacity: 1;
    }

    100% {
        opacity: 0;
    }
}






















.tinder {

    margin: auto;
    display: flex;
    flex-direction: column;
    position: relative;
    opacity: 0;
    transition: opacity 0.1s ease-in-out;
    margin-top: auto;
    width: 100vw;
    height: 90vh;




}

.loaded.tinder {
    opacity: 1;
}

.tinder--status {
    position: absolute;
    top: 50%;
    margin-top: -30px;
    z-index: 2;
    width: 100%;
    text-align: center;
    pointer-events: none;
}

.tinder--status i {
    font-size: 100px;
    opacity: 0;
    transform: scale(0.3);
    transition: all 0.2s ease-in-out;
    position: absolute;
    width: 100px;
    margin-left: -50px;
}

.fa {
    width: 100px;
}

.tinder_love .fa-heart {
    opacity: 0.3;
    transform: scale(1);
}

.tinder_nope .fa-remove {
    opacity: 0.3;
    transform: scale(1);
}

.tinder--cards {
    flex-grow: 1;
    padding-top: 10px;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: flex-end;
    z-index: 1;
}

.tinder--card {
    display: inline-block;
    width: 45vw;
    height: 80vh;
    background: #FFFFFF;
    border-radius: 8px;
    overflow: hidden;
    position: absolute;
    will-change: transform;
    transition: all 0.3s ease-in-out;
    cursor: -webkit-grab;
    cursor: -moz-grab;
    cursor: grab;
}

.moving.tinder--card {
    transition: none;
    cursor: -webkit-grabbing;
    cursor: -moz-grabbing;
    cursor: grabbing;
}

.tinder--card img {
    max-width: 100%;
    pointer-events: none;
}

.tinder--card h3 {
    margin-top: 32px;
    font-size: 32px;
    padding: 0 16px;
    pointer-events: none;
}

.tinder--card p {
    margin-top: 24px;
    font-size: 20px;
    padding: 0 16px;
    pointer-events: none;
}

.tinder--buttons {
    flex: 0 0 100px;
    text-align: center;
}

.tinder--buttons button {
    border-radius: 50%;
    line-height: 60px;
    width: 60px;
    border: 0;
    background: #FFFFFF;
    display: inline-block;
    margin: 0 8px;
}

.tinder--buttons button:focus {
    outline: 0;
}

.tinder--buttons i {
    font-size: 32px;
    vertical-align: middle;
}

.fa-heart {
    color: #FFACE4;
}

.fa-remove {
    color: #CDD6DD;
}</style>
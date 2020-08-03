<template>
  <div class="photoContainer">
    <header>
        <!-- TODO Create a linke that will take you to the user page -->
        <p id="userName">{UserName}</p>
    </header>
    <section>
        <img src="https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg?crop=1.00xw:0.669xh;0,0.190xh&resize=1200:*" alt="">
    </section>
    <section class="actions">
        <div>He is a good boy!</div>
        <span>{Like}</span>
        <span>{Favorite}</span>
    </section>
    <section class="comments">
        <div>
            <p class="comment"> {UserName}
                <span>What a good boy!</span></p>
        </div>
    </section>
  </div>
</template>

<script>
export default {
    name: 'photo-container',
    props: {
        photo: Object
    }
}
</script>

<style scoped>
.photoContainer {
    margin: 0 35vh 0 35vh;
    background-color: rgba(var(--d87,255,255,255),1);
    border: 1px solid rgba(var(--b6a,219,219,219),1);
    text-align: left;
}

#userName {
    
}

img {
    width: 100%;
    padding: -1
}

.actions {
    
}
</style>
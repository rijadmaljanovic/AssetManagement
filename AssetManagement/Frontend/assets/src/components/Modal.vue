<template>
  <!-- <div v-if="modalActive">
           
                    <i class="fas fa-times" @click="$root.$emit('modal_close')"></i>
                    <slot name="test"></slot>
                    <button @click="$root.$emit('modal_close')">Close</button>
                    <button>Save</button>
    </div> -->
  <div v-if="modalActive" class="modal-backdrop" @click.self="close">
    <div class="modal-dialog modal-dialog-scrollable">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="text-uppercase modal-title">{{ modal_title }}</h5>
          <button
            type="button"
            class="btn-close"
            @click="$root.$emit('modal_close')"
          ></button>
        </div>
        <div class="modal-body scrollbar-deep-purple bordered-deep-purple">
          <slot name="body"></slot>
        </div>
        <div class="modal-footer">
          <slot name="footer"></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Modal",
  data() {
    return {
      modalActive: false,
    };
  },
  props: ["modal_title", "modal_id"],
  methods: {
    close() {
      this.modalActive = false;
    },
  },
  created() {
    this.$root.$on("modal_close", () => {
      this.close();
    });
    //Open the modal from outside the component (modal_id required)
    this.$root.$on(`${this.modal_id}_open`, () => {
      this.modalActive = true;
    });
  },
};
</script>

<style>
@media (min-width: 576px) {
  .modal-dialog {
    max-width: 450px;
    margin: 1.75rem auto;
  }
}

.modal-content {
  display: flex;
  flex-direction: column;
  width: 100%;
  pointer-events: auto;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid transparent;
  border-radius: 1rem;
  outline: 0;
  padding: 15px;
}

.stylemap {
  width: 100% !important;
}

h5 {
  font-weight: 700;
}
.modal-backdrop {
  /* background-color: rgb(161, 161, 163);  */
  opacity: 0.96;
}
.modal-dialog {
  background-color: white !important;
  overflow: hidden;
}

.scrollbar-deep-purple::-webkit-scrollbar-track {
background-color: #F5F5F5;
border-radius: 10px; }

.scrollbar-deep-purple::-webkit-scrollbar {
width: 6px;
background-color: #F5F5F5; }

.scrollbar-deep-purple::-webkit-scrollbar-thumb {
border-radius: 10px;
background-color: #4650dd; }

.scrollbar-deep-purple {
scrollbar-color: #4650dd #F5F5F5;
}

</style>
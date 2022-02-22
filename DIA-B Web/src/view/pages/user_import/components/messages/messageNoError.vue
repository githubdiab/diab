<template>
         
  <b-modal
    id="user-import-modal"
    ref="user-import-modal"
    
    
  >
            <div style="text-align:center;">
            <span class="svg-tick" >
            <inline-svg src="/media/svg/import/sss.svg" style="justify-self: center;"/>
             </span>
            </div>
           
         <div  style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;">

          
         {{this.staff_list.length+"/"+staff_list.length}} bản ghi  thỏa mãn điều kiện. Bạn có muốn tiếp tục Import dữ liệu?
         
          </div>
    <template #modal-footer style="text-align:center">
        <!--<b-button class="btn btn-secondary" href="#" tabindex="0">
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/power.svg" />
          </span>
          Hủy
        </b-button> -->
      
          

        <b-button
          class="btn btn-success ml-2"
          href="#"
          @click="goback"
          tabindex="0"
          style="width:90px"
        >
        
          Huỷ
        
        </b-button>

        <b-button
          class="btn btn-success ml-2"
          href="#"
          @click="handleClick"
          tabindex="0"
        >
        <span class="svg-icon">
            <inline-svg src="/media/svg/import/tick.svg" />
          </span>
         Đồng ý
          
        </b-button>

        
      
      
    </template>
  </b-modal>
</template>

<script>

export default {
  name: 'Modal',   
 props: {
    staff_list: {
      type: Array,
      default: () => [],
    },
  },
  computed:{
   tableLength: function () {
     
     
    //  var totalcount = this.column[2].key
      return this.num;
    },
  },
  data() {
    return {
      isMounted: false,
      loading: false,
      isSelectFile: false,
      form: {},
      validationState: {},
      error: {},
    };
  },
  methods: {
  //  onClickButton (event) {
  //        this.$emit('clicked', 'someValue')
  //    },
    goback() {
      this.$bvModal.hide('user-import-modal');
    },
  },
};
</script>

<style lang="scss">
#glucose-modal {
  .modal-dialog {
    // width: 370px;
    // height: 582px;
   
  }
}
.modal-footer{
  justify-content: center;
  //text-align: center;
}
.svg-tick{
    justify-content: center;
}


</style>

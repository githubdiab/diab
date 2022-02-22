<template>
         
  <b-modal
    id="user-import-modal2"
    ref="user-import-modal2"
    
    
  >
            <div style="text-align:center; ">
            <span class="svg-tick" >
            <inline-svg src="/media/svg/import/sss.svg" style="justify-self: center;"/>
             </span>
            </div>
           
          <div style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;;">
          
            Tổng số khách hàng import thành công: {{96}}
         
          </div>

          <div style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;;">
          
             Tổng số bản ghi import thành công: {{960}}
         
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
          @click="handleClick"
          tabindex="0"
        >
        
        Tiếp tục
          
        </b-button>

        
      
      
    </template>
  </b-modal>
 
</template>

<script>
export default {
  name: 'Modal',
 
  computed: {},
  watch: {},
  // mounted() {this.$root.$on('Modal',()=>{
  //   this.handleClick()
  // })},
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
    handleClick() {
      this.$refs.form.importForm();
    },
    onUpload(payload) {
      this.isSelectFile = payload;
    },
    importForm(payload) {
      this.handleSubmit(payload);
    },
    async handleSubmit(payload) {
      this.loading = true;
      let result = [];
      try {
        //if (true) {
        await this.$api
          .post('Admin/Import/staff', payload, {
            headers: {
              'Content-Type': 'multipart/form-data',
            },
          })
          .then(({ data }) => {
            result = data.staffList;
          })
          .finally(() => {
            this.$store.commit('context/setLoading', false);
          });
        //}
        this.$toastr.s({
          title: 'Thành công!',
          msg: `Import thành công`,
        });

        // TODO
        // this.$emit('loadData', result);
        //console.log("aa");
        this.$router.push({
          name: 'loading',
          params: {
            staff_list: result,
          },
        });
        this.$bvModal.hide('user-import-modal2');
      } catch (error) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: error,
        });
      } finally {
        this.loading = false;
      }
      // this.loading = false;
    },
    goback() {
      this.$bvModal.hide('user-import-modal2');
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

<template>
         
  <b-modal
    id="user-import-modal2"
    ref="user-import-modal2"
    hide-header
  no-close-on-backdrop
  no-stacking
    
  >
            <div style="text-align:center; ">
            <span class="svg-tick" >
            <inline-svg src="/media/svg/import/sss.svg" style="justify-self: center;"/>
             </span>
            </div>
           
          <div style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;;">
          
            Tổng số khách hàng import thành công: {{count_NewUser}}
         
         
          </div>

          <div style="text-align:center;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 14px;;">
          
             Tổng số bản ghi import thành công: {{this.staff_list.length}} 
         
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
          @click="handleClick()"
          tabindex="0"
        >
        
        Tiếp tục
          
        </b-button>

        
      
      
    </template>
  </b-modal>
 
</template>

<script>
//import axios from 'axios'

export default {
  name: 'Modal',
  props:{
    staff_list: {
      type: Array,
      default: () => [],
  },
  
  },
  computed: {
   
   count_NewUser: function()
   {  
     const uniqueValues = new Set(this.staff_list.map(v => v.user_code));
     let result =0;
if (uniqueValues.size < this.staff_list.length) {
 result =uniqueValues.size
  }
else
  {
result =uniqueValues.size;
  }
     return result
   },
 
  },


  watch: {},
 
  data() {
    return {
      isMounted: false,
      loading: false,
      isSelectFile: false,
      form: {},
      validationState: {},
      error: {},
      account_list:[],
    };
  },
  created() {
     
      
    },
    
  mounted(){
   
  // this.loadData_account();        
    

    
    
      
  },

  methods: {
   
 async  handleClick() {
     this.$store.commit('context/setLoading', true);
   await this.AddSurveyDetails().then(this.goback()).catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        }).catch((error) => {
          this.$toastr.e({
            title: 'Lỗi',
            msg: error,
          });
        })
        .finally(() => {
          this.$store.commit('context/setLoading', false);
           this.$router.push({
        name: 'user_import_list',
         method:{
          // staff_list : data
          },
        params: {
          
         staff_list : this.staff_list
        },
          })
        });
        
       
  
    },
  
  async AddSurveyDetails ()
 {


 const data = await this.$api.get('SurveyImport/id')         // lay tat ca survey_id tu survey_imports
     

    
const data_code = await this.$api.get('AccountImport/account')        // get user_code 
  

     for(let n=0;n<data_code.length;n++)             // vong lap user_code
     {
     for(let m=0;m<data.length;m++)             // vong lap survey_id
     {
     for(let k=0;k<Number(this.staff_list.length);k++)     // vong lap file excel 
     {
             
      { 
       if(data_code[n].user_code===Number(this.staff_list[k].user_code) && data[m].survey_code===this.staff_list[k].survey_code && data_code[n].user_name===this.staff_list[k].user_name && data[m].user_id===data_code[n].id )        // so sanh user_code
       {

      {
       await  this.$api.post('SurveyImportDetails',{headers: {'Content-Type': 'application/json'}}, {
      params: {
       survey_id : data[m].id,
    
       category_code : this.staff_list[k].category_code,
       category: this.staff_list[k].category,
       sub_category_code: this.staff_list[k].sub_category_code,
       sub_category:this.staff_list[k].sub_category,
       question_code:this.staff_list[k].question_code,
       question_number:this.staff_list[k].question_number,
       question_answer:this.staff_list[k].question_answer,
       question_result:this.staff_list[k].question_result,
           
        },
      });  
    
       }
     }
      }
  
     }
     }
     }
 },
    goback() {
      this.$bvModal.hide('user-import-modal2');
    },
    goOn() {
      
    },

     loadData_account() {
     
      this.$api.get('SurveyImportDetails', {
          //params: { ...this.searchParams },
        })
        .then(({ data }) => {
          this.selected = [];
          this.data = data.items || [];
          this.paging.total = data.total;
          this.account_list = data
        })
        
      return;
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

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
import axios from 'axios'

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
  //    elimited: function() {
  //     return this.staff_list.filter(function(item) {
  //       return
  //     });
    

  // },



  },


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
      account_list:[],
    };
  },
  created() {
     
      
    },
    
  mounted(){
   
  // this.loadData_account();        
    

    
    
      
  },

  methods: {
   
    handleClick() {
     
      this.AddSurveyDetails();
       this.$router.push({
        name: 'user_import_list',
         method:{
          // staff_list : data
          },
        params: {
          
         staff_list : this.staff_list
        },
          })
  
    },
  
  async AddSurveyDetails ()
 {
  // this.addUser();
 //  this.AddSurvey();
 

 const data = await axios.get('https://localhost:44380/api/surveyimport/id',{          // lay tat ca survey_id tu survey_imports
        params:{}}).then(res => res.data);

    
const data_code = await axios.get('https://localhost:44380/api/accountimport/account',{        
       params:{}}).then(res => res.data);


//const number_question = await axios.get('https://localhost:44380/api/surveyimportdetails',{        
     //  params:{}}).then(res => res.data);

 //    var isInsert=false;
     
     // for(let m=0;m<=this.staff_list.length;m++)
   // {
      
 
 //    n++;
   //   }
       //  let count=0;

     for(let n=0;n<=data_code.length;n++)
     {
     for(let k=0;k<Number(this.staff_list.length);k++)
     {
       
   
           
      { 
       if((data_code[n].user_code===Number(this.staff_list[k].user_code))===true)
       {
       // return true ;  
        // if(number_question[n].question_number!==this.staff_list[k].question_number)

    {
       await  axios.post('https://localhost:44380/api/surveyimportdetails', null, {
      params: {
       survey_id : data[n].id,
     // user_id: '1a9d3f69-40b2-4206-b59e-dc4ea6c3a18c',
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
     //   console.log(true,count++,[n , k]);
    //   console.log(number_question[n].number_question)
       }
       if(data_code[n].user_code!==Number(this.staff_list[k].user_code))
       {
       console.log(false + [n,k]);                     
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
     
      axios.get('https://localhost:44380/api/surveyimportdetails', {
          params: { ...this.searchParams },
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

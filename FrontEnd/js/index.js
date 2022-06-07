const Url = "https://localhost:44318/api/WindDatas"

Vue.createApp({
    data(){
        return{
            winddatas: [],
            newWindData: {"id":0,"direction":"","speed":0},
            speedFilter: 0,
            filteredList: []
        }
    },
    created(){
        this.getAllWindData()
    },
    methods: {
        async helperGetAndShow(url){
            try{
                const response = await axios.get(url)
                this.winddatas = await response.data
            } catch (ex){
                alert(ex.message)
            }
        },

        getAllWindData(speedFilter){
            let url = Url
            if(speedFilter > 0){
                url = Url + "?speed=" + speedFilter
            }
            this.helperGetAndShow(url)


        },

        filterJS(){
            let result = this.winddatas.filter(speed => speed.speed > this.speedFilter)
            return result
        }
    }
}).mount('#app')
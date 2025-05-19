import React, { useState, useEffect } from 'react';
import {
  View,
  Text,
  StyleSheet,
  TouchableOpacity,
  ImageBackground,
  FlatList,
  Platform,
} from 'react-native';
import DateTimePicker from '@react-native-community/datetimepicker';
import PageContainer from '../components/PageContainer';
import Button from '../components/Button.Js';

export default function Agendamento({ route, navigation }) {
  const { servico } = route.params;

  const [dataSelecionada, setDataSelecionada] = useState(new Date());
  const [mostrarDatePicker, setMostrarDatePicker] = useState(false);
  const [horariosDisponiveis, setHorariosDisponiveis] = useState([]);
  const [horarioSelecionado, setHorarioSelecionado] = useState(null);
  const [barbeirosDisponiveis, setBarbeirosDisponiveis] = useState([]);
  const [barbeiroSelecionado, setBarbeiroSelecionado] = useState(null);

useEffect(() => {
  const horarios = [
    '08:00', '08:15', '08:30', '08:45',
    '09:00', '09:15', '09:30', '09:45',
    '10:00', '10:15', '10:30', '10:45',
    '11:00', '11:15', '11:30', '11:45',
    '12:00', '12:15', '12:30', '12:45',
    '13:00', '13:15', '13:30', '13:45',
    '14:00', '14:15', '14:30', '14:45',
    '15:00', '15:15', '15:30', '15:45',
    '16:00', '16:15', '16:30', '16:45',
    '17:00', '17:15', '17:30', '17:45',
    '18:00', '18:15', '18:30', '18:45',
    '19:00',
  ];
  setHorariosDisponiveis(horarios);
  setHorarioSelecionado(null);
  setBarbeirosDisponiveis([]);
  setBarbeiroSelecionado(null);
  console.log('Horários carregados:', horarios);
}, [dataSelecionada]);

  useEffect(() => {
    if (horarioSelecionado) {
      setBarbeirosDisponiveis([
        { id: 1, nome: 'Beatriz Ribeiro'},
        { id: 2, nome: 'Ramon Wesley'},
        { id: 3, nome: 'Sávio Matos'},
      ]);
    }
  }, [horarioSelecionado]);

  const onConfirmarAgendamento = () => {
    alert(
      `Agendado: ${servico.titulo}\nData: ${dataSelecionada.toLocaleDateString()}\nHora: ${horarioSelecionado}\nBarbeiro: ${barbeiroSelecionado?.nome}`
    );
  };

  return (
    <ImageBackground
      source={require('../assets/background-2.png')}
      style={styles.background}
    >
      <PageContainer>
        <Text style={styles.title}>Agendamento</Text>

        <View style={styles.card}>
          <Text style={styles.servico}>{servico.titulo}</Text>
          <Text style={styles.info}>{servico.preco}  |  {servico.duracao}</Text>
        </View>

        <TouchableOpacity onPress={() => setMostrarDatePicker(true)}>
          <Text style={styles.label}>Selecionar data:</Text>
          <Text style={styles.date}>{dataSelecionada.toLocaleDateString()}</Text>
        </TouchableOpacity>

        {mostrarDatePicker && (
          <DateTimePicker
            value={dataSelecionada}
            mode="date"
            display={Platform.OS === 'ios' ? 'spinner' : 'default'}
            onChange={(event, selectedDate) => {
              setMostrarDatePicker(false);
              if (selectedDate) setDataSelecionada(selectedDate);
            }}
          />
        )}

        {horariosDisponiveis.length > 0 && (
          <View style={styles.section}>
            <Text style={styles.label}>Horários disponíveis:</Text>
            <FlatList
              horizontal
              data={horariosDisponiveis}
              keyExtractor={(item) => item}
              renderItem={({ item }) => (
                <TouchableOpacity
                  style={[
                    styles.option,
                    horarioSelecionado === item && styles.optionSelecionado,
                  ]}
                  onPress={() => setHorarioSelecionado(item)}
                >
                  <Text style={styles.optionText}>{item}</Text>
                </TouchableOpacity>
              )}
            />
          </View>
        )}

        {barbeirosDisponiveis.length > 0 && (
          <View style={styles.section}>
            <Text style={styles.label}>Barbeiros disponíveis:</Text>
            <FlatList
              horizontal
              data={barbeirosDisponiveis}
              keyExtractor={(item) => item.id.toString()}
              renderItem={({ item }) => (
                <TouchableOpacity
                  style={[
                    styles.option,
                    barbeiroSelecionado?.id === item.id && styles.optionSelecionado,
                  ]}
                  onPress={() => setBarbeiroSelecionado(item)}
                >
                  <Text style={styles.optionText}>{item.nome}</Text>
                </TouchableOpacity>
              )}
            />
          </View>
        )}

        {horarioSelecionado && barbeiroSelecionado && (
          <View style={styles.buttonWrapper}>
            <Button title="Confirmar Agendamento" onPress={onConfirmarAgendamento} />
          </View>
        )}
      </PageContainer>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  title: {
    color: '#fff',
    fontSize: 22,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 30,
    marginTop: 30,
  },
  card: {
    backgroundColor: 'rgba(54,54,54,0.9)',
    borderRadius: 20,
    padding: 15,
    marginBottom: 25,
  },
  servico: {
    color: '#fff',
    fontWeight: 'bold',
    fontSize: 16,
    textAlign: 'center',
    marginBottom: 5,
  },
  info: {
    color: '#fff',
    textAlign: 'center',
    marginBottom: 5,
  },
  label: {
    color: '#fff',
    fontWeight: '600',
    marginBottom: 5,
  },
  date: {
    color: '#fff',
    marginBottom: 20,
  },
  section: {
    marginBottom: 20,
  },
  option: {
    backgroundColor: '#555',
    paddingHorizontal: 15,
    paddingVertical: 10,
    borderRadius: 10,
    marginRight: 10,
  },
  optionSelecionado: {
    backgroundColor: '#fff',
  },
  optionText: {
    color: '#fff',
    fontWeight: 'bold',
  },
  buttonWrapper: {
    marginTop: 20,
  },
});